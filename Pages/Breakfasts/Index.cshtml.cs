using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;

namespace Eduard_Sergiu.Pages.Breakfasts
{
    public class IndexModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public IndexModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        public IList<Breakfast> Breakfast { get;set; } = default!;

        public BreakfastData BreakfastD { get; set; }
        public int BreakfastID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string RestaurantSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string
searchString)
        {
            BreakfastD = new BreakfastData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            RestaurantSort = String.IsNullOrEmpty(sortOrder) ? "restaurant_desc" : "";
            CurrentFilter = searchString;

            BreakfastD.Breakfasts = await _context.Breakfast
            .Include(b => b.Restaurant)
            .Include(b => b.Chef)
            .Include(b => b.FoodCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                BreakfastD.Breakfasts = BreakfastD.Breakfasts.Where(s => s.Restaurant.RestaurantName.Contains(searchString)

               || s.Restaurant.RestaurantName.Contains(searchString)
               || s.Title.Contains(searchString));
            }

                if (id != null)
            {
                BreakfastID = id.Value;
                Breakfast breakfast = BreakfastD.Breakfasts
                .Where(i => i.ID == id.Value).Single();
                BreakfastD.Categories = breakfast.FoodCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "title_desc":
                    BreakfastD.Breakfasts = BreakfastD.Breakfasts.OrderByDescending(s =>
                   s.Title);
                    break;
                case "restaurant_desc":
                    BreakfastD.Breakfasts = BreakfastD.Breakfasts.OrderByDescending(s =>
                   s.Restaurant.RestaurantName);
                    break;

            }

        }

    }
}
