using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;
using Eduard_Sergiu.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Eduard_Sergiu.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public IndexModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BreakfastID { get; set; }

        public async Task OnGetAsync(int? id, int? BookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.FoodCategories)
            .ThenInclude(i => i.Breakfast)
            .ThenInclude(i => i.Restaurant)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories.Where(i => i.ID == id.Value).Single();
                CategoryData.FoodCategories = category.FoodCategories;
            }
        }
    }
}
