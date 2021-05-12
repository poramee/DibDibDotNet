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
        public IActionResult AdminSelectRoom(string roomId)
        {
            Room roomModel = new Room();
            roomModel.RoomNumber = roomId;
            if (roomId == "ECC-501")
            {
                roomModel.EquipmentName = "Xilinx Spartan-6 FPGA";
                roomModel.PicLocation = "/Assets/ImageRoom501.png";
            }
            return View(roomModel);
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