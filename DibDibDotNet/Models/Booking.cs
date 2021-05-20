using System.Collections.Generic;
namespace DibDibDotNet.Models
{
  public class Booking
  {
    public Booking()
    {
    }
    public int Day { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }
  }

  public class TimeSlot
  {
    public TimeSlot() { }

    public int Slot { get; set; }
    public int BookCount { get; set; }
    public int Balance { get; set; }
  }
}