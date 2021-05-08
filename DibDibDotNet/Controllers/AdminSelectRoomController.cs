using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DibDibDotNet.Models;

namespace DibDibDotNet.Controllers
{
    public class AdminSelectRoomController : Controller
    {
        private readonly ILogger<AdminSelectRoomController> _logger;

        public AdminSelectRoomController(ILogger<AdminSelectRoomController> logger)
        {
            _logger = logger;
        }

        public IActionResult AdminSelectRoom()
        {
            return View();
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