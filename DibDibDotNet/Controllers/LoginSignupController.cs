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
  public class LoginSignupController : Controller
  {
    private readonly ILogger<LoginSignupController> _logger;
    private readonly DibDibDotNetContext _context;

    public LoginSignupController(ILogger<LoginSignupController> logger, DibDibDotNetContext context)
    {
      _logger = logger;
      _context = context;
    }

    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Email,Password")] User user)
    {
      if (ModelState.IsValid)
      {
        var currentUser = _context.User.Where(e => e.Email.Equals(user.Email) && e.Password.Equals(user.Password)).ToList();
        if (currentUser.Count() > 0)
        {
          //add session
          //   Console.WriteLine(user.Email, user.Password);
          //   Console.WriteLine(user.Password, user.Password);
          Console.WriteLine(currentUser.FirstOrDefault().FullName);
          //   HttpContext.Session.SetString("FullName", currentUser.FirstOrDefault().FullName);
          //   HttpContext.Session.SetString("Email", currentUser.FirstOrDefault().Email);
          //   HttpContext.Session.SetString("idUser", currentUser.FirstOrDefault().Id.ToString());
          //   Console.WriteLine(HttpContext.Session.GetString("FullName"));
          return RedirectToAction("HomeUser", "HomeUser");
        }
        else
        {
          ViewBag.error = "Login failed";
          return RedirectToAction("Login");
        }
      }
      return View(user);
    }


    public IActionResult SignUp()
    {
      return View();
    }
  }
}