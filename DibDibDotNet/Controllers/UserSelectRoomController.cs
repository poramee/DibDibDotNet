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

        public IActionResult UserSelectRoom(string roomId, string yearMonth)
        {

            var currentUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
            Console.WriteLine(roomId);
            Console.WriteLine(yearMonth);
            var equipmentInfo = _context.Equipment.FirstOrDefault(e => e.Room.Equals(roomId));
            ViewBag.Month = yearMonth;
            ViewBag.EquipmentName = equipmentInfo.Name;
            ViewBag.EquipmentRoom = equipmentInfo.Room;

            int daysInMonth =
                DateTime.DaysInMonth(int.Parse(yearMonth.Split("-")[0]), int.Parse(yearMonth.Split("-")[1]));
            var booking = new List<Booking>();
            
            booking.Add(new Booking{Day=0,TimeSlots = new List<TimeSlot>()}); // Dummy Element
            for (int i = 1; i <= daysInMonth; ++i)
            {
                var currentBookingData = new Booking();
                currentBookingData.Day = i;
                currentBookingData.TimeSlots = new List<TimeSlot>();
                for (int slotI = 9; slotI <= 15; ++slotI)
                {
                    DateTime slotDate = new DateTime(int.Parse(yearMonth.Split("-")[0]),
                        int.Parse(yearMonth.Split("-")[1]), i);
                    var transactionInPeriod = _context.Transaction.Where(e => e.Equipment.Id.Equals(equipmentInfo.Id) && DateTime.Equals(e.Date, slotDate) && e.Period.Equals(slotI));
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

                    Console.WriteLine("UserSelectRoom");
                    Console.WriteLine(currentUserBookAmount);
                    currentBookingData.TimeSlots.Add(new TimeSlot{Slot=slotI, BookCount = currentUserBookAmount, Balance = int.Parse(equipmentInfo.Total) - transactionBookAmount});
                }
                booking.Add(currentBookingData);
            }

            return View(booking);
        }
    }
}