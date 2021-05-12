using System;
using System.Net.NetworkInformation;

namespace DibDibDotNet.Models
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public string EquipmentName { get; set; }
        public int CurrentAmount { get; set; }
        public string PicLocation { get; set; }

        public Room()
        {
            RoomNumber = null;
            EquipmentName = null;
            CurrentAmount = 50;
        }

    }
}