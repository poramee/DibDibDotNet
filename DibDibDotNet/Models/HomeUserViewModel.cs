using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DibDibDotNet.Models
{
    public class HomeUserViewModel
    {
        public User CurrentUser { get; set; }
        public Dictionary<string, Equipment> Equipments { get; set; } = new Dictionary<string, Equipment>();
        public UpdateAccount NewAccountInfo { get; set; }

    }
}