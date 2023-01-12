namespace Eduard_Sergiu.Models
{
    public class FoodCategory
    {
        public int ID { get; set; }
        public int BreakfastID { get; set; }
        public Breakfast Breakfast { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
