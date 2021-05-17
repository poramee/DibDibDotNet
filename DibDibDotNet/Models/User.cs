using System;
using System.ComponentModel.DataAnnotations;
namespace DibDibDotNet.Models
{
  public class User
  {
    public User()
    {
    }
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // [CompareAttribute("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
    // public string ConfirmPassword { get; set; }
    public string FullName { get; set; }

    public bool IsAdmin { get; set; }
    public bool IsValid { get; set; }
  }
}
