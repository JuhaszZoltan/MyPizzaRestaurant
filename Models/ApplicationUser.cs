using Microsoft.AspNetCore.Identity;

namespace MyPizzaRestaurant.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Order>? Orders { get; set; }
}
