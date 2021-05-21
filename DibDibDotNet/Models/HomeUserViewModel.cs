using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DibDibDotNet.Models
{
    public class HomeUserViewModel
    {
        public User CurrentUser { get; set; }
        public Dictionary<int, Equipment> Equipments { get; set; } = new Dictionary<int, Equipment>();
        public UpdateAccount NewAccountInfo { get; set; }
    }
}