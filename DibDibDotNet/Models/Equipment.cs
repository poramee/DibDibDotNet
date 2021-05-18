using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace DibDibDotNet.Models
{
  public class Equipment
  {
    public Equipment()
    {
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Room { get; set; }
    public string Total { get; set; }

    [NotMapped]
    public int Booking { get; set; }
    [NotMapped]
    public int Avaliable => int.Parse(Total) - Booking;

    [NotMapped]
    public string PicLocation { get; set; }

    [NotMapped]
    public int Amount { get; set; }

    [NotMapped]
    public int InCreateAmount => Amount++;

    [NotMapped]
    public string TransactionDate { get; set; }

    [NotMapped]
    public virtual EquipmentTransaction[] EquipmentTransaction { get; set; }
  }
}
