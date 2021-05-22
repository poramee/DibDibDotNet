using System;
using System.ComponentModel.DataAnnotations;
namespace DibDibDotNet.Models
{
  public class Register
  {
    public Register()
    {
    }
    public int Id { get; set; }
    
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    
    [RegularExpression(".+", ErrorMessage = "First Name must not be empty")]
    public string FirstName { get; set; }
    [RegularExpression(".+", ErrorMessage = "Last Name must not be empty")]
    public string LastName { get; set; }

  }
}
