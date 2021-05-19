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
            Console.WriteLine("DB Password  " + currentAccount.Password);
            if (currentAccount.Password != userInfo.CurrentPassword)
            {
                // ViewBag.showAlert = true;
                // ViewBag.alertMessage = "Current password is incorrect.";
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
            var equipmentList = _context.Equipment.ToList();
            
            foreach (var e in equipmentList)
            {
                e.Booking = _context.Transaction.Count(a => a.Equipment.Id.Equals(e.Id));
                homeUserModel.Equipments.Add(e.Room, e);
            }
            return View(homeUserModel);
        }
    }
}