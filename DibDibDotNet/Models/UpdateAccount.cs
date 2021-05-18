using System;
using System.ComponentModel.DataAnnotations;
namespace DibDibDotNet.Models
{
  public class UpdateAccount
  {
    public UpdateAccount()
    {
    }
    public int Id { get; set; }
    public string Email { get; set; }

    [Required]
    public string NewPassword { get; set; }
    
    [Required]
    public string CurrentPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

  }
}
