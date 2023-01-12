namespace Eduard_Sergiu.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string RestaurantName { get; set; }
        public ICollection<Breakfast>? Breakfasts { get; set; }
    }
}
