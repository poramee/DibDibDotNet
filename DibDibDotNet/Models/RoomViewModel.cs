using System;
using System.Net.NetworkInformation;

namespace DibDibDotNet.Models
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public string EquipmentName { get; set; }
        public int ReserveAmt { get; set; }
        public int RemainingAmt { get; set; }
        public int TotalAmt { get; set; }
        public string PicLocation { get; set; }

        public Room(string roomId)
        {
            RoomNumber = roomId;
            if (roomId == "ECC-501")
            {
                EquipmentName = "Xilinx Spartan-6 FPGA";
                PicLocation = "/Assets/ImageRoom501.png";
            }else if (roomId == "ECC-502")
            {
                EquipmentName = "YIHUA-948 (2 in 1)";
                PicLocation = "/Assets/ImageRoom502.png";                
            }else if (roomId == "ECC-504")
            {
                EquipmentName = "MULTI METER DT1008";
                PicLocation = "/Assets/ImageRoom504.png";                
            }else if (roomId == "ECC-601")
            {
                EquipmentName = "STANLEY SCH-12S2-B1";
                PicLocation = "/Assets/ImageRoom601.png";                
            }else if (roomId == "ECC-602")
            {
                EquipmentName = "STM32 NUCLEO-F767ZI";
                PicLocation = "/Assets/ImageRoom602.png";                
            }
            ReserveAmt = 6;
            RemainingAmt = 77;
            TotalAmt = ReserveAmt + RemainingAmt;
        }
    }
}