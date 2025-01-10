namespace MyPizzaRestaurant.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    //ha van FK
    public string? UserId { get; set; }
    //akkor van navigation property is!
    public ApplicationUser User { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}