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
      var userBooking = _context.Transaction.Where(e => e.Equipment.Id.Equals(equipment.Id)).ToList();
      int BookCount = 0;
      foreach (var item in userBooking)
      {
        BookCount += item.Amount;
      }
      equipment.Booking = BookCount;
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

    public IActionResult ManageBooking(string roomId, string month)
    {
      var CurrentDate = DateTime.Now;
      TempData["CurrentMonth"] = month;
      TempData["RoomName"] = roomId;
      var equipment = _context.Equipment.Where(equipment => equipment.Room.Equals(roomId)).ToList().FirstOrDefault();
      TempData["EquipmentName"] = equipment.Room;
      TempData["EquipmentId"] = equipment.Id;

      TempData["Total"] = equipment.Total;
      TempData["Year"] = month.Split("-")[0];
      TempData["Month"] = month.Split("-")[1];
      int days = DateTime.DaysInMonth(int.Parse(month.Split("-")[0]), int.Parse(month.Split("-")[1]));
      var BookSlots = new List<Booking>();

      for (int i = 0; i < days; i++)
      {
        BookSlots.Add(new Booking { Day = i + 1, TimeSlots = new List<TimeSlot>() });
        for (int timeSlotIndex = 9; timeSlotIndex <= 15; timeSlotIndex++)
        {
          DateTime SlotDate = new DateTime(int.Parse(month.Split("-")[0]), int.Parse(month.Split("-")[1]), i + 1);
          var TransactionInPeriod = _context.Transaction.Where(e => e.Equipment.Id.Equals(equipment.Id) && DateTime.Equals(e.Date, SlotDate) && e.Period.Equals(timeSlotIndex)).ToList();
          int TransactionBookAmount = 0;
          foreach (var item in TransactionInPeriod)
          {
            TransactionBookAmount += item.Amount;
          }
          BookSlots[i].TimeSlots.Add(new TimeSlot { Slot = timeSlotIndex, BookCount = TransactionBookAmount, Balance = int.Parse(equipment.Total) - TransactionBookAmount });
        }
        // for (int timeSlotIndex = 0; timeSlotIndex < BookSlots[i].TimeSlots.Length; timeSlotIndex++)
        // {
        //   BookSlots[i].TimeSlots.Append(new TimeSlot { Slot = timeSlotIndex + 9 });
        // }
        // @foreach (var item in BookSlots[i].TimeSlots)
        // {
        //     ite,
        // }

      }
      return View(BookSlots.ToList());
    }
    public IActionResult MemberRoom()
    {
      var userList = _context.User.ToList();
      foreach (var item in userList)
      {
        item.FirstName = item.FullName.Split(" ")[0];
        item.LastName = item.FullName.Split(" ")[1];
      }
      return View(userList);
    }


    public async Task<IActionResult> DeleteUser(string userId)
    {
      Console.WriteLine(userId);
      var user = new User { Id = int.Parse(userId) };
      var transactionList = _context.Transaction.Where(e => e.User.Id.Equals(user.Id)).ToList();
      _context.RemoveRange(transactionList);
      _context.Remove(user);
      await _context.SaveChangesAsync();
      return RedirectToAction("MemberRoom");
    }

    public async Task<IActionResult> BlackListUser(string userId)
    {
      var user = _context.User.Where(e => e.Id.Equals(int.Parse(userId))).ToList().FirstOrDefault();
      user.IsValid = !user.IsValid;
      _context.Update(user);
      await _context.SaveChangesAsync();
      return RedirectToAction("MemberRoom");
    }

    public string GetTransaction(string userId)
    {
      return "done";
    }
  }
}