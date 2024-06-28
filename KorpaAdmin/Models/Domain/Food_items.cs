namespace KorpaAdmin.Models.Domain
{
    public class Food_items
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }

        public Guid RestaurantId { get; set; }
        public Restaurants Restaurant { get; set; }

    }
}
