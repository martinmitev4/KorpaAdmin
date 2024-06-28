namespace KorpaAdmin.Models.Domain
{
    public class FoodInOrder
    {
        public Guid Food_ItemsId { get; set; }
        public Food_items Food_Items { get; set; }
        public Guid Delivery_OrdersId { get; set; }
        public Delivery_orders Delivery_Orders { get; set; }
        public int Quantity { get; set; }

    }
}
