using Microsoft.AspNetCore.Identity;

namespace todonote.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Location { get; set; }
    }
}