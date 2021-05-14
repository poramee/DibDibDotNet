using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace DibDibDotNet.Models
{
    public class HomeAdmin
    {
        public Dictionary<string, Room> RoomList { get; set; } = new Dictionary<string, Room>();

        public HomeAdmin()
        {
            List<string> roomList = new List<string>(){"ECC-501","ECC-502","ECC-504","ECC-601","ECC-602"};
            foreach (string room in roomList)
            {
                RoomList.Add(room,new Room(room));
            }
        }
    }
}