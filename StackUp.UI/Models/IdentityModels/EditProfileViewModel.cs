using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.IdentityModels;

public class EditProfileViewModel
{
    [Required]
    public string FirstName { get; set; }
        
    [Required]
    public string LastName { get; set; }
        
    [Required]
    [EmailAddress]
    public string Email { get; set; }
        
    [Required]
    public string UserName { get; set; }
    
    public string? PhoneNumber { get; set; }
    public IFormFile? ImageFile { get; set; } 
    public string? ImageUrl { get; set; }
}