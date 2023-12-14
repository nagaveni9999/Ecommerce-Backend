using Microsoft.AspNetCore.Identity;

namespace Onlineshopping11.Models
{
    public class ApplicationUsers:IdentityUser
    {
        public string CustomerName { get; set; }
    }
}
