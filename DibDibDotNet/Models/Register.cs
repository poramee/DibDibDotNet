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
    
    
    [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Email format is incorrect")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(".{6,}", ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }

    [Compare("Password")]
    [RegularExpression(".{6,}", ErrorMessage = "Password must be at least 6 characters")]
    public string ConfirmPassword { get; set; }
    
    [RegularExpression(".+", ErrorMessage = "First Name must not be empty")]
    public string FirstName { get; set; }
    [RegularExpression(".+", ErrorMessage = "Last Name must not be empty")]
    public string LastName { get; set; }

  }
}
