using KorpaAdmin.Models.Identity;

namespace KorpaAdmin.Models.Domain
{
    public class Delivery_orders 
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public String? Address { get; set; }
        public IEnumerable<FoodInOrder>? FoodInOrders { get; set; }

    }
}
