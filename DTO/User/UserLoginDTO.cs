using System.ComponentModel.DataAnnotations;

namespace FleamarketApp.DTO;

public class UserLoginDTO 
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string UnhashedPassword { get; set; }
}