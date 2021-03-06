using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Http;

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
      if (HttpContext.Session.GetString("idUser") != null)
      {
        var currentUser = _context.User.Where(e => e.Id.Equals(int.Parse(HttpContext.Session.GetString("idUser")))).ToList().FirstOrDefault();
        Console.WriteLine("currentUser " + currentUser.IsAdmin);
        if (!currentUser.IsAdmin)
        {
          Response.StatusCode = 404;
          return Redirect("/");
        }
      }
      else
      {
        Response.StatusCode = 404;
        return Redirect("/");
      }
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

      var equipmentTransactions = _context.EquipmentTransaction.Where(e => e.Equipment.Id.Equals(equipment.Id)).ToList();
      int upCount = 0;
      int downCount = 0;
      foreach (var item in equipmentTransactions)
      {
        if (item.IsUp)
        {
          upCount += item.Amount;
        }
        else
        {
          downCount += item.Amount;
        }

      }
      TempData["UpCount"] = upCount;
      TempData["DownCount"] = downCount;

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
      currentEquipment.Total = (int.Parse(currentEquipment.Total) - equipment.Amount > 0 ? int.Parse(currentEquipment.Total) - equipment.Amount : 0).ToString();
      _context.Update(currentEquipment);
      _context.Add(newEquipmentTransaction);
      await _context.SaveChangesAsync();
      return RedirectToAction("AdminSelectRoom", new { roomId = equipment.Room });
    }

    public IActionResult ManageBooking(string roomId, string month)
    {
      if (HttpContext.Session.GetString("idUser") != null)
      {
        var currentUser = _context.User.Where(e => e.Id.Equals(int.Parse(HttpContext.Session.GetString("idUser")))).ToList().FirstOrDefault();
        if (!currentUser.IsAdmin)
        {
          Response.StatusCode = 404;
          return Redirect("/");
        }
      }
      else
      {
        Response.StatusCode = 404;
        return Redirect("/");
      }
      var CurrentDate = DateTime.Now;
      TempData["CurrentMonth"] = month;
      TempData["RoomName"] = roomId;
      var equipment = _context.Equipment.Where(equipment => equipment.Room.Equals(roomId)).ToList().FirstOrDefault();
      TempData["EquipmentName"] = equipment.Room;
      TempData["EquipmentId"] = equipment.Id;

      TempData["Total"] = equipment.Total;
      TempData["Year"] = month.Split("-")[0];
      TempData["Month"] = month.Split("-")[1];
      TempData["LastReloadDate"] = DateTime.Now;
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
      }
      return View(BookSlots.ToList());
    }
    public IActionResult MemberRoom()
    {
      if (HttpContext.Session.GetString("idUser") != null)
      {
        var currentUser = _context.User.Where(e => e.Id.Equals(int.Parse(HttpContext.Session.GetString("idUser")))).ToList().FirstOrDefault();
        Console.WriteLine("currentUser " + currentUser.IsAdmin);
        if (!currentUser.IsAdmin)
        {
          Response.StatusCode = 404;
          return Redirect("/");
        }
      }
      else
      {
        Response.StatusCode = 404;
        return Redirect("/");
      }
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
      var equipmentTransaction = _context.Transaction.Where(e => e.User.Id.Equals(user.Id)).ToList();
      _context.Update(user);
      _context.RemoveRange(equipmentTransaction);
      await _context.SaveChangesAsync();
      return RedirectToAction("MemberRoom");
    }

    [HttpPost]
    [Route("AdminSelectRoom/GetTransaction")]
    public JsonResult GetTransaction(string Year, string Month, string Date, string EquipmentId, string SlotId)
    {
      DateTime requestDate = new DateTime(int.Parse(Year), int.Parse(Month), int.Parse(Date));
      var transactions = _context.Transaction.Where(e => e.Equipment.Id.Equals(int.Parse(EquipmentId)) && DateTime.Equals(e.Date, requestDate) && e.Period.Equals(int.Parse(SlotId))).Select(e => new { e.User, e.Amount, TxId = e.Id }).ToList();
      // TempData["ModalTransaction"] = transaction;
      return Json(transactions);
    }

    [HttpPost]
    [Route("AdminSelectRoom/DeleteTransaction")]
    public async Task<JsonResult> DeleteTransaction(string TxId)
    {
      var transaction = new Transaction { Id = int.Parse(TxId) };
      _context.Remove(transaction);
      await _context.SaveChangesAsync();
      return Json(TxId);
    }

    [HttpPost]
    [Route("AdminSelectRoom/BlackListUserTransaction")]
    public async Task<JsonResult> BlackListUserTransaction(string UserId)
    {
      var user = _context.User.Where(e => e.Id.Equals(int.Parse(UserId))).ToList().FirstOrDefault();
      user.IsValid = false;
      var equipmentTransaction = _context.Transaction.Where(e => e.User.Id.Equals(user.Id)).ToList();
      _context.Update(user);
      _context.RemoveRange(equipmentTransaction);
      await _context.SaveChangesAsync();
      return Json(UserId);
    }
  }
}