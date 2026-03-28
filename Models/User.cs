using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginRegisterForm.Models;

public partial class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Login required")]
    [StringLength(36, MinimumLength = 4, ErrorMessage = "Login: 4-36 symbols")]
    [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Only letters, numbers & _")]
    public string Login { get; set; } = null!;
    
    [Required(ErrorMessage = "Email required")]
    [StringLength(255)]
    [EmailAddress(ErrorMessage = "Not email form")]
    public string Email { get; set; } = null!;
    
    public string PasswordHash { get; set; } = null!;
    
}
