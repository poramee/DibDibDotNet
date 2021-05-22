using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace DibDibDotNet.Models
{
    public class HomeUserViewModel
    {
        public User CurrentUser { get; set; }
        public Dictionary<int, Equipment> Equipments { get; set; } = new Dictionary<int, Equipment>();
        public UpdateAccount NewAccountInfo { get; set; }
        
    }

    public class EquipmentReservationListViewModel
    {
        public int TransactionId { get; set; } 
        public Equipment Equipment { get; set; }
        public DateTime Date { get; set; }
        public int Period { get; set; }
        public int Amount { get; set; }
    }
}