using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(HomeUserViewModel info)
        {
            var userInfo = info.NewAccountInfo;
            var currentAccount = _context.User.Find(Int32.Parse(HttpContext.Session.GetString("idUser")));

            if (currentAccount.Password != userInfo.CurrentPassword)
            {
                Console.WriteLine("Failed to change the info");
            }
            else
            {
                currentAccount.FullName = userInfo.FirstName + " " + userInfo.LastName;
                currentAccount.Email = userInfo.Email;
                currentAccount.Password = userInfo.NewPassword;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("HomeUser");
        }

        public IActionResult HomeUser()
        {
            Console.WriteLine(HttpContext.Session.GetString("idUser"));

            int idUser = Int32.Parse(HttpContext.Session.GetString("idUser"));
            HomeUserViewModel homeUserModel = new HomeUserViewModel();
            homeUserModel.CurrentUser = _context.User.Find(idUser);
            homeUserModel.CurrentUser.FirstName = homeUserModel.CurrentUser.FullName.Split(" ")[0];
            homeUserModel.CurrentUser.LastName = homeUserModel.CurrentUser.FullName.Split(" ")[1];
        
            var equipmentList = _context.Equipment.ToList();

            foreach (var e in equipmentList)
            {
                e.Booking = _context.Transaction.Count(a => a.Equipment.Id.Equals(e.Id)); // TODO: This algorithm might be wrong.
                homeUserModel.Equipments.Add(e.Id, e);
            }

            ViewBag.TransactionList = new List<EquipmentReservationListViewModel>();
            ViewBag.NumUserBooked = 0;
            var userTransactionList= _context.Transaction.Where(t => t.User.Id.Equals(idUser));
            foreach (var transaction in userTransactionList)
            {
                ViewBag.NumUserBooked += transaction.Amount;
            }
            
            return View(homeUserModel);
        }

        [HttpGet]
        public ActionResult GetUserReservationMonth(string monthUser)
        {
            Console.Write("GET: ");
            Console.WriteLine(monthUser);

            int idUser = Int32.Parse(HttpContext.Session.GetString("idUser"));

            var searchResult = _context.Transaction.Where(t => t.User.Id.Equals(idUser));

            var dateTimeUser = DateTime.Parse(monthUser + "-1");
            searchResult =
                searchResult.Where(t => t.Date.Year == dateTimeUser.Year && t.Date.Month == dateTimeUser.Month);
            
            // foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(searchResultList[0]))
            // {
            //     string name = descriptor.Name;
            //     object value = descriptor.GetValue(searchResultList[0]);
            //     Console.WriteLine("{0}={1}", name, value);
            // }
            
            var temp = searchResult.Select(t => new EquipmentReservationListViewModel{TransactionId = t.Id,Equipment = t.Equipment, Date = t.Date, Period = t.Period, Amount = t.Amount}).ToList();

            ViewBag.TransactionList = temp;
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