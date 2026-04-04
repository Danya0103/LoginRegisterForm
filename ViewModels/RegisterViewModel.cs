using System.ComponentModel.DataAnnotations;
namespace LoginRegisterForm.ViewModels;

public class RegisterViewModel
{
    
    [Required(ErrorMessage = "Login required")]
    [StringLength(36, MinimumLength = 4, ErrorMessage = "Login: 4-36 symbols")]
    [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Only letters, numbers & _")]
    public string Login { get; set; } = null!;
    
    [Required(ErrorMessage = "Email required")]
    [StringLength(255)]
    [EmailAddress(ErrorMessage = "Not email form")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Password required")]
    [StringLength(64, MinimumLength = 8, ErrorMessage = "Password: 8-64 symbols")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required(ErrorMessage = "Confirm required")]
    [Compare(nameof(Password), ErrorMessage = "You stupid (^^)")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}