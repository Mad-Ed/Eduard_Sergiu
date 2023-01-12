using Eduard_Sergiu.Migrations;

namespace Eduard_Sergiu.Models
{
    public class BreakfastData
    {
        public IEnumerable<Breakfast> Breakfasts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FoodCategory> FoodCategories { get; set; }

    }
}
