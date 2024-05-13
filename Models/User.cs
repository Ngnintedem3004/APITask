using Microsoft.AspNetCore.Identity;

namespace ManagementDesTaches.Models
{
    public class User:IdentityUser
    {
        public string  FirstName { get; set; }
    }
}
