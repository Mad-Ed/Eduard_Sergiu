namespace Eduard_Sergiu.Models
{
    public class Chef
    {
        public int ID { get; set; }
        public string ChefName { get; set; }
        public ICollection<Breakfast>? Breakfasts { get; set; }
    }
}
