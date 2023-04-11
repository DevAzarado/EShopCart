using Microsoft.AspNetCore.Identity;

namespace EShopCart.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
