
namespace StackUp.UI.Models.IdentityModels;
public class EditUserViewModel
{
    public string Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public List<RoleViewModel>? Roles { get; set; }
}
