using System;
using System.ComponentModel.DataAnnotations;
namespace DibDibDotNet.Models
{
  public class EquipmentTransaction
  {
    public EquipmentTransaction()
    {
    }
    public int Id { get; set; }
    public virtual Equipment Equipment { get; set; }
    public int Amount { get; set; }
    public bool IsUp { get; set; }

    public string CreateAt { get; set; }
  }
}