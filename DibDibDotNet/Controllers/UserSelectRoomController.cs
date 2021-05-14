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
    public class UserSelectRoomController : Controller
    {
        private readonly ILogger<UserSelectRoomController> _logger;

        public UserSelectRoomController(ILogger<UserSelectRoomController> logger)
        {
            _logger = logger;
        }

        public IActionResult UserSelectRoom(string roomId)
        {
            Room roomModel = new Room(roomId);
            return View(roomModel);
        }
    }
}