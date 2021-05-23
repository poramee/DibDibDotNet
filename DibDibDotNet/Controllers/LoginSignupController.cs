using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Http;

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
      if (HttpContext.Session.GetString("idUser") != null)
      {
        var currentUser = _context.User.Where(e => e.Id.Equals(int.Parse(HttpContext.Session.GetString("idUser")))).ToList().FirstOrDefault();
        if (currentUser != null) return RedirectToAction("HomeUser", "HomeUser");
        return RedirectToAction("Login");
      }
      return View();
    }

    public IActionResult Logout()
    {
      HttpContext.Session.Remove("idUser");
      return RedirectToAction("Login");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login([Bind("Email,Password")] User user)
    {
      if (ModelState.IsValid && user.Email.Length > 0)
      {
        var currentUser = _context.User.Where(e => e.Email.Equals(user.Email) && e.Password.Equals(user.Password)).ToList();
        if (currentUser.Count() > 0)
        {
          HttpContext.Session.SetString("idUser", currentUser.FirstOrDefault().Id.ToString());
          // TODO: Check Is Admin And Redirect To Home Admin Page
          return RedirectToAction("HomeUser", "HomeUser");
        }
        else
        {
          ViewBag.showAlert = true; // "True"
          ViewBag.alertMessage = "Username or Password invalid";
          return RedirectToAction("Login");
        }
      }
      return View(user);
    }


    public IActionResult SignUp()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(Register userInfo)
    {
      // TODO: Make Register Validation Here - DONE
      bool validFirstName = (new Regex(@".+")).IsMatch(userInfo.FirstName);
      bool validLastName = (new Regex(@".+")).IsMatch(userInfo.LastName);
      bool validEmail =
        (new Regex(
          @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
        .IsMatch(userInfo.Email);
      bool validPassword = userInfo.Password.Equals(userInfo.ConfirmPassword) && (new Regex(".+")).IsMatch(userInfo.Password);
      bool infoValid = validFirstName && validLastName && validEmail && validPassword;
      
      if (ModelState.IsValid && userInfo.Email.Length > 0 && infoValid)
      {
        var newUser = new User { Email = userInfo.Email, FullName = userInfo.FirstName + ' ' + userInfo.LastName, Password = userInfo.Password, IsAdmin = false, IsValid = true };
        _context.Add(newUser);
        await _context.SaveChangesAsync();
        return RedirectToAction("Login");
      }
      return View(userInfo);
    }
  }
}