using Eduard_Sergiu.Migrations;

namespace Eduard_Sergiu.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FoodCategory> FoodCategories { get; set; }
        public IEnumerable<Breakfast> Breakfasts { get; set; }
    }
}
