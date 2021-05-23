using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DibDibDotNet.Controllers
{
    public class UserSelectRoomController : Controller
    {
        private readonly ILogger<UserSelectRoomController> _logger;
        private readonly DibDibDotNetContext _context;


        public UserSelectRoomController(ILogger<UserSelectRoomController> logger, DibDibDotNetContext context)
        {
            _logger = logger;
            _context = context;
        }

        private int GetNumUserBooked(int currentUser)
        {
            int numUserBooked = 0;
            var userTransactionListAll = _context.Transaction.Where(t => t.User.Id.Equals(currentUser));
            foreach (var transaction in userTransactionListAll)
            {
                numUserBooked += transaction.Amount;
            }

            return numUserBooked;
        }

        public IActionResult UserSelectRoom(string roomId, string yearMonth)
        {
            var currentUser = Int32.Parse(HttpContext.Session.GetString("idUser"));

            ViewBag.TransactionList = new List<EquipmentReservationListViewModel>(); // For Cart Popup
            ViewBag.NumUserBooked = GetNumUserBooked(currentUser);


            Console.WriteLine(roomId);
            Console.WriteLine(yearMonth);
            var equipmentInfo = _context.Equipment.FirstOrDefault(e => e.Room.Equals(roomId));
            ViewBag.Month = yearMonth;
            ViewBag.Equipment = equipmentInfo;

            int daysInMonth =
                DateTime.DaysInMonth(int.Parse(yearMonth.Split("-")[0]), int.Parse(yearMonth.Split("-")[1]));
            var booking = new List<Booking>();

            booking.Add(new Booking {Day = 0, TimeSlots = new List<TimeSlot>()}); // Dummy Element
            for (int i = 1; i <= daysInMonth; ++i)
            {
                var currentBookingData = new Booking();
                currentBookingData.Day = i;
                currentBookingData.TimeSlots = new List<TimeSlot>();
                for (int slotI = 9; slotI <= 15; ++slotI)
                {
                    DateTime slotDate = new DateTime(int.Parse(yearMonth.Split("-")[0]),
                        int.Parse(yearMonth.Split("-")[1]), i);
                    var transactionInPeriod = _context.Transaction.Where(e =>
                        e.Equipment.Id.Equals(equipmentInfo.Id) && DateTime.Equals(e.Date, slotDate) &&
                        e.Period.Equals(slotI));
                    var transactionInPeriodList = transactionInPeriod.ToList();
                    int transactionBookAmount = 0;
                    foreach (var item in transactionInPeriodList)
                    {
                        transactionBookAmount += item.Amount;
                    }

                    var currentUserBookAmount = 0;
                    var userTransactionList =
                        transactionInPeriod.Where(t => t.User.Id.Equals(currentUser)).ToList();

                    foreach (var item in userTransactionList)
                    {
                        currentUserBookAmount += item.Amount;
                    }

                    currentBookingData.TimeSlots.Add(new TimeSlot
                    {
                        Slot = slotI, BookCount = currentUserBookAmount,
                        Balance = int.Parse(equipmentInfo.Total) - transactionBookAmount
                    });
                }

                booking.Add(currentBookingData);
            }

            return View(booking);
        }

        [HttpGet]
        [Route("UserSelectRoom/MakeReservation")]
        public JsonResult MakeReservation(string date, int slot, int equipmentId, int amount)
        {
            var reservationDate = new DateTime(Int32.Parse(date.Split('-')[0]), Int32.Parse(date.Split('-')[1]),
                Int32.Parse(date.Split('-')[2]));
            var userId = HttpContext.Session.GetString("idUser");
            Console.WriteLine("MakeReservation");
            Console.WriteLine(userId);
            Console.WriteLine(reservationDate.ToString());
            Console.WriteLine(slot);
            Console.WriteLine(amount);

            int numUserBooked = GetNumUserBooked(Int32.Parse(userId));
            var transactionInPeriod = _context.Transaction.Count(e =>
                e.Equipment.Id.Equals(equipmentId) && DateTime.Equals(e.Date, reservationDate) &&
                e.Period.Equals(slot));

            if (numUserBooked + amount <= 5 && numUserBooked <= transactionInPeriod)
            {
                var newTransaction = new Transaction
                {
                    UserId = Int32.Parse(userId),
                    EquipmentId = equipmentId,
                    Period = slot,
                    Amount = amount,
                    Date = reservationDate,
                    Status = false
                };

                _context.Add<Transaction>(newTransaction);
                _context.SaveChanges();
                var returnJson = new
                {
                    status = "success"
                };
                return Json(JsonSerializer.Serialize(returnJson));
            }
            else
            {
                var reason = "";

                if (numUserBooked + amount <= 5) reason = "Quota Exceeded";
                else if (numUserBooked <= transactionInPeriod) reason = "Insufficient Equipment Available";
                 var returnJson = new
                {
                    status = "failed",
                    detail = reason,
                };
                return Json(JsonSerializer.Serialize(returnJson));
            }
        }
    }
}