using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using DibDibDotNet.Data;

namespace DibDibDotNet.Controllers
{
  [ApiController]
  public class APIController : Controller
  {
    private readonly ILogger<APIController> _logger;
    private readonly DibDibDotNetContext _context;

    public APIController(ILogger<APIController> logger, DibDibDotNetContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet("api/reservation")]
    public IActionResult GetAllReservation(string Date)
    {
      //   var transaction = new Transaction { Id = int.Parse(TxId) };
      if (Date == null) Date = DateTime.Now.ToString("dd-MM-yyyy");
      int Year = int.Parse(Date.Split("-")[2]);
      int Month = int.Parse(Date.Split("-")[1]);
      int Day = int.Parse(Date.Split("-")[0]);
      DateTime RequestDate = new DateTime(Year, Month, Day);

      var equipmentList = _context.Equipment;
      equipmentList.Select(e => new { e.Id, e.Room, e.Name, e.Total }).ToList();
      var result = new List<Reservation>();
      foreach (var equipment in equipmentList)
      {
        var reservation = new List<TimeSlot>();
        for (int i = 9; i <= 15; i++)
        {
          int reservationCount = 0;
          var transactionList = _context.Transaction.Where(e => e.Equipment.Id.Equals(equipment.Id) && DateTime.Equals(e.Date, RequestDate) && e.Period.Equals(i)).ToList();
          foreach (var transaction in transactionList)
          {
            reservationCount += transaction.Amount;
          }
          reservation.Add(new TimeSlot { Slot = i, BookCount = reservationCount, Balance = int.Parse(equipment.Total) - reservationCount });
        }
        result.Add(new Reservation { Id = equipment.Id.ToString(), Equipment = equipment.Name, Room = equipment.Room, TimeSlots = reservation });
      }
      return Json(result);
    }
  }
}