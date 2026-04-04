using System.ComponentModel.DataAnnotations;
namespace LoginRegisterForm.ViewModels;

public class LoginViewModel
{
    
    public string Login { get; set; } = null!;
    
    // [EmailAddress]
    // public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password required")]
    // [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}