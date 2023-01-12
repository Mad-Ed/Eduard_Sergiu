using Microsoft.AspNetCore.Mvc.RazorPages;
using Eduard_Sergiu.Data;
namespace Eduard_Sergiu.Models
{
    public class FoodCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Eduard_SergiuContext context,
        Breakfast breakfast)
        {
            var allCategories = context.Category;
            var foodCategories = new HashSet<int>(
            breakfast.FoodCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = foodCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFoodCategories(Eduard_SergiuContext context,
        string[] selectedCategories, Breakfast breakfastToUpdate)
        {
            if (selectedCategories == null)
            {
                breakfastToUpdate.FoodCategories = new List<FoodCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var foodCategories = new HashSet<int>
            (breakfastToUpdate.FoodCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!foodCategories.Contains(cat.ID))
                    {
                        breakfastToUpdate.FoodCategories.Add(
                        new FoodCategory
                        {
                            BreakfastID = breakfastToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (foodCategories.Contains(cat.ID))
                    {
                        FoodCategory courseToRemove
                        = breakfastToUpdate
                        .FoodCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}
