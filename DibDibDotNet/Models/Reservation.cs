using System.Collections.Generic;
namespace DibDibDotNet.Models
{
  public class Reservation
  {
    public Reservation()
    {
    }
    public string Id { get; set; }
    public string Equipment { get; set; }
    public string Room { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }

  }

}