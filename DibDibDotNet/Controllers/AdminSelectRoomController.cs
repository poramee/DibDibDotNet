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
  public class AdminSelectRoomController : Controller
  {
    private readonly ILogger<AdminSelectRoomController> _logger;
    private readonly DibDibDotNetContext _context;

    public AdminSelectRoomController(ILogger<AdminSelectRoomController> logger, DibDibDotNetContext context)
    {
      _logger = logger;
      _context = context;
    }
    public IActionResult AdminSelectRoom(string roomId)
    {
      Console.WriteLine(" admin select room " + roomId);
      var equipment = _context.Equipment.Where(e => e.Room.Equals(roomId)).ToList().FirstOrDefault();
      var transaction = _context.EquipmentTransaction.Where(e => e.Equipment.Id.Equals(equipment.Id)).ToArray();
      Console.Write(transaction);
      equipment.EquipmentTransaction = transaction;
      var userBooking = _context.Transaction.Where(e => e.Equipment.Id.Equals(equipment.Id)).Count();
      equipment.Booking = userBooking;
      switch (roomId)
      {
        case "ECC-501":
          equipment.PicLocation = "/Assets/ImageRoom501.png";
          break;
        case "ECC-502":
          equipment.PicLocation = "/Assets/ImageRoom502.png";
          break;
        case "ECC-504":
          equipment.PicLocation = "/Assets/ImageRoom504.png";
          break;
        case "ECC-601":
          equipment.PicLocation = "/Assets/ImageRoom601.png";
          break;
        case "ECC-602":
          equipment.PicLocation = "/Assets/ImageRoom602.png";
          break;
        default:
          break;
      }
      return View(equipment);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEquipmentTransaction(Equipment equipment)
    {
      Console.WriteLine(equipment.TransactionDate);
      Console.WriteLine(equipment.Amount);
      var currentEquipment = _context.Equipment.Where(e => e.Id.Equals(equipment.Id)).ToList().FirstOrDefault();
      var newEquipmentTransaction = new EquipmentTransaction { Equipment = currentEquipment, CreateAt = equipment.TransactionDate, Amount = equipment.Amount, IsUp = true };
      currentEquipment.Total = (int.Parse(currentEquipment.Total) + equipment.Amount).ToString();
      _context.Update(currentEquipment);
      _context.Add(newEquipmentTransaction);
      await _context.SaveChangesAsync();
      return RedirectToAction("AdminSelectRoom", new { roomId = equipment.Room });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveEquipmentTransaction(Equipment equipment)
    {
      Console.WriteLine(equipment.TransactionDate);
      Console.WriteLine(equipment.Amount);
      var currentEquipment = _context.Equipment.Where(e => e.Id.Equals(equipment.Id)).ToList().FirstOrDefault();
      var newEquipmentTransaction = new EquipmentTransaction { Equipment = currentEquipment, CreateAt = equipment.TransactionDate, Amount = equipment.Amount, IsUp = false };
      currentEquipment.Total = (int.Parse(currentEquipment.Total) - equipment.Amount).ToString();
      _context.Update(currentEquipment);
      _context.Add(newEquipmentTransaction);
      await _context.SaveChangesAsync();
      return RedirectToAction("AdminSelectRoom", new { roomId = equipment.Room });
    }

    public IActionResult ManageBooking()
    {
      return View();
    }
    public IActionResult MemberRoom()
    {
      return View();
    }
  }
}