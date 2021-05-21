using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DibDibDotNet.Controllers
{
  public class HomeAdminController : Controller
  {
    private readonly ILogger<HomeAdminController> _logger;
    private readonly DibDibDotNetContext _context;
    public HomeAdminController(ILogger<HomeAdminController> logger, DibDibDotNetContext context)
    {
      _logger = logger;
      _context = context;
    }

    public async Task<IActionResult> HomeAdmin()
    {
      var userRegistered = _context.User.Where(e => e.IsValid.Equals(true)).Count();
      var userBlackList = _context.User.Where(e => e.IsValid.Equals(false)).Count();

      TempData["Register"] = userRegistered;
      TempData["BlackList"] = userBlackList;
      var items = await _context.Equipment.ToListAsync();
      foreach (var item in items)
      {
        var userBooking = _context.Transaction.Where(e => e.Equipment.Id.Equals(item.Id)).Count();
        item.Booking = userBooking;
      }
      return View(items);
    }
  }
}