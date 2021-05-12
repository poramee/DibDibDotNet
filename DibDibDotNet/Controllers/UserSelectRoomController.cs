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
            Room roomModel = new Room();
            roomModel.RoomNumber = roomId;
            if (roomId == "ECC-501")
            {
                roomModel.EquipmentName = "Xilinx Spartan-6 FPGA";
                roomModel.PicLocation = "/Assets/ImageRoom501.png";
            }else if (roomId == "ECC-502")
            {
                roomModel.EquipmentName = "YIHUA-948 (2 in 1)";
                roomModel.PicLocation = "/Assets/ImageRoom502.png";                
            }else if (roomId == "ECC-504")
            {
                roomModel.EquipmentName = "MULTI METER DT1008";
                roomModel.PicLocation = "/Assets/ImageRoom504.png";                
            }else if (roomId == "ECC-601")
            {
                roomModel.EquipmentName = "STANLEY SCH-12S2-B1";
                roomModel.PicLocation = "/Assets/ImageRoom601.png";                
            }else if (roomId == "ECC-602")
            {
                roomModel.EquipmentName = "STM32 NUCLEO-F767ZI";
                roomModel.PicLocation = "/Assets/ImageRoom602.png";                
            }
            return View(roomModel);
        }
    }
}