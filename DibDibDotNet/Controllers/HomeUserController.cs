using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace DibDibDotNet.Controllers
{
  public class HomeUserController : Controller
  {
    private readonly ILogger<HomeUserController> _logger;
    private readonly DibDibDotNetContext _context;

    public HomeUserController(ILogger<HomeUserController> logger, DibDibDotNetContext context)
    {
      _logger = logger;
      _context = context;
    }


    public string UpdateAccountInfo(string firstName, string lastName, string email, string currentPassword,
        string newPassword)
    {
      Console.WriteLine("Update Account Info");
      var currentAccount = _context.User.Find(Int32.Parse(HttpContext.Session.GetString("idUser")));

      if (newPassword != null && currentPassword != null)
      {
        if (currentAccount.Password != currentPassword)
        {
          return "Failed - Current password is incorrect";
        }
        else if (newPassword.Length < 6) return "Failed - New password must be at least 6 characters";
        else
        {
          currentAccount.Password = newPassword;
        }
      }
      else if (newPassword != null && currentPassword == null) return "Failed - Please enter current password";
      else if (newPassword == null && currentPassword != null) return "Failed - Please enter new password";

      var emailValidator = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

      if (!emailValidator.IsMatch(email)) return "Failed - Invalid email format";

      currentAccount.FullName = firstName + " " + lastName;
      currentAccount.Email = email;
      _context.SaveChanges();

      return "Success";
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAccount(HomeUserViewModel info)
    {
      var userInfo = info.NewAccountInfo;
      var msg = UpdateAccountInfo(userInfo.FirstName, userInfo.LastName, userInfo.Email, userInfo.CurrentPassword,
          userInfo.NewPassword);

      return RedirectToAction("HomeUser", new { alertMsg = msg });
    }

    public IActionResult UpdateAccountUserSelect(string roomId, string yearMonth, string firstName, string lastName,
        string email, string currentPassword, string newPassword)
    {
      Console.WriteLine(firstName);
      Console.WriteLine(lastName);
      Console.WriteLine(email);
      Console.WriteLine(currentPassword);
      Console.WriteLine(newPassword);

      var msg = UpdateAccountInfo(firstName, lastName, email, currentPassword, newPassword);

      return RedirectToAction("UserSelectRoom", "UserSelectRoom", new { roomId, yearMonth, alertMsg = msg });
    }

    public IActionResult HomeUser(string alertMsg)
    {
      ViewBag.alertMsg = alertMsg;
      Console.WriteLine(HttpContext.Session.GetString("idUser"));

      int idUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
      HomeUserViewModel homeUserModel = new HomeUserViewModel();
      homeUserModel.CurrentUser = _context.User.Find(idUser);
      homeUserModel.CurrentUser.FirstName = homeUserModel.CurrentUser.FullName.Split(" ")[0];
      homeUserModel.CurrentUser.LastName = homeUserModel.CurrentUser.FullName.Split(" ")[1];

      var equipmentList = _context.Equipment.ToList();

      // var currentTime = new DateTime(2021,5,25,9,0,0); // Test
      var currentTime = DateTime.Now;
      var currentTimeWithoutTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day);

      foreach (var e in equipmentList)
      {
        var currentSlotTransaction = _context.Transaction.Where(a =>
            a.Equipment.Id.Equals(e.Id) && a.Date.Equals(currentTimeWithoutTime) && a.Period.Equals(currentTime.Hour));
        var equipmentBookingAmount = 0;
        foreach (var t in currentSlotTransaction)
        {
            ViewBag.alertMsg = alertMsg;
            Console.WriteLine(HttpContext.Session.GetString("idUser"));

            int idUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
            HomeUserViewModel homeUserModel = new HomeUserViewModel();
            homeUserModel.CurrentUser = _context.User.Find(idUser);
            homeUserModel.CurrentUser.FirstName = homeUserModel.CurrentUser.FullName.Split(" ")[0];
            homeUserModel.CurrentUser.LastName = homeUserModel.CurrentUser.FullName.Split(" ")[1];

            var equipmentList = _context.Equipment.ToList();

            
            var currentTime = DateTime.Now;
            var currentTimeWithoutTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day);

            foreach (var e in equipmentList)
            {
                var currentSlotTransaction = _context.Transaction.Where(a =>
                    a.Equipment.Id.Equals(e.Id) && a.Date.Equals(currentTimeWithoutTime) && a.Period.Equals(currentTime.Hour));
                var equipmentBookingAmount = 0;
                foreach (var t in currentSlotTransaction)
                {
                    equipmentBookingAmount += t.Amount;
                }

                e.Booking = equipmentBookingAmount;
                
                Console.WriteLine(e.Booking);
                homeUserModel.Equipments.Add(e.Id, e);
            }

            
            ViewBag.NumUserBooked = 0;
            var userTransactionList = _context.Transaction.Where(t => t.User.Id.Equals(idUser));
            foreach (var transaction in userTransactionList)
            {
                ViewBag.NumUserBooked += transaction.Amount;
            }

            return View(homeUserModel);
        }

        e.Booking = equipmentBookingAmount;

        Console.WriteLine(e.Booking);
        homeUserModel.Equipments.Add(e.Id, e);
      }


      ViewBag.NumUserBooked = 0;
      var userTransactionList = _context.Transaction.Where(t => t.User.Id.Equals(idUser));
      foreach (var transaction in userTransactionList)
      {
        ViewBag.NumUserBooked += transaction.Amount;
      }

      return View(homeUserModel);
    }

            var transactionGrouping = new SortedDictionary<DateTime, SortedList<int,EquipmentReservationListViewModel>>();

      int idUser = Int32.Parse(HttpContext.Session.GetString("idUser"));

            foreach (var transaction in temp)
            {
                if (!transactionGrouping.ContainsKey(transaction.Date))
                {
                    transactionGrouping.Add(transaction.Date, new SortedList<int,EquipmentReservationListViewModel>());
                }
                transactionGrouping[transaction.Date].Add(transaction.Period,transaction);
            }
            

            ViewBag.TransactionList = transactionGrouping;
            return PartialView("_EquipmentReserveListPartial");

      var dateTimeUser = DateTime.Parse(monthUser + "-1");
      searchResult =
          searchResult.Where(t => t.Date.Year == dateTimeUser.Year && t.Date.Month == dateTimeUser.Month);

      var temp = searchResult.Select(t => new EquipmentReservationListViewModel
      {
        TransactionId = t.Id,
        Equipment = t.Equipment,
        Date = t.Date,
        Period = t.Period,
        Amount = t.Amount
      })
          .ToList();

      var transactionGrouping = new Dictionary<DateTime, List<EquipmentReservationListViewModel>>();


      foreach (var transaction in temp)
      {
        if (!transactionGrouping.ContainsKey(transaction.Date))
        {
          transactionGrouping.Add(transaction.Date, new List<EquipmentReservationListViewModel>());
        }
        transactionGrouping[transaction.Date].Add(transaction);
      }


      ViewBag.TransactionList = transactionGrouping;
      return PartialView("_EquipmentReserveListPartial");
    }


    [HttpGet]
    public JsonResult CancelTransaction(int transactionId)
    {
      Console.WriteLine("CancelTransaction");
      Console.WriteLine(transactionId);
      var transaction = new Transaction { Id = transactionId };
      _context.Remove(transaction);
      _context.SaveChanges();

      return Json("'status': 'success'");
    }
  }
}
