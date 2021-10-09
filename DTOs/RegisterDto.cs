using System.ComponentModel.DataAnnotations;

namespace dotnet_identity_sample.DTOs
{
  public class RegisterDto
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string UserName { get; set; }
  }
}