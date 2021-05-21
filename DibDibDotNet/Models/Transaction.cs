using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DibDibDotNet.Models
{
  public class Transaction
  {
    public Transaction()
    {
    }
    public int Id { get; set; }
    public virtual User User { get; set; }
    public virtual Equipment Equipment { get; set; }
    public int Period { get; set; }
    public int Amount { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    public bool Status { get; set; }

    [NotMapped]
    public string FirstName { get; set; }
    [NotMapped]
    public string LastName { get; set; }
    [NotMapped]
    public string Email { get; set; }
  }
}
