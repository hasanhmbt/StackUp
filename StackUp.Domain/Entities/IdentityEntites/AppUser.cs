using Microsoft.AspNetCore.Identity;

namespace StackUp.Domain.Entities.IdentityEntites
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
