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
      Console.WriteLine(" admin select room ", roomId);
      //   var ecc501Pic = "/Assets/ImageRoom501.png";
      //   var ecc502Pic = "/Assets/ImageRoom502.png";
      //   var ecc504Pic = "/Assets/ImageRoom504.png";
      //   var ecc601Pic = "/Assets/ImageRoom601.png";
      //   var ecc602Pic = "/Assets/ImageRoom501.png";
      var equipment = _context.Equipment.Where(e => e.Room.Equals(roomId)).ToList().FirstOrDefault();
      //     var ecc501 = Model.Find(x => x.Room.Equals("ECC-501"));
      // var ecc502 = Model.Find(x => x.Room.Equals("ECC-502"));
      // var ecc504 = Model.Find(x => x.Room.Equals("ECC-504"));
      // var ecc601 = Model.Find(x => x.Room.Equals("ECC-601"));
      // var ecc602 = Model.Find(x => x.Room.Equals("ECC-602"));
      var userBooking = _context.Transaction.Where(e => e.Equipment.Id.Equals(equipment.Id)).Count();
      equipment.Booking = userBooking;
      switch (roomId)
      {
        case "ECC-501":
          equipment.PicLocation = "/Assets/ImageRoom501.png";
          break;
        default:
          break;
      }
      return View(equipment);
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