using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace StackUp.UI.Models.IdentityModels;
[AllowAnonymous]
public class LoginViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
