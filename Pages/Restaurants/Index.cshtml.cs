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

namespace Eduard_Sergiu.Pages.Restaurants
{
    
    public class IndexModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public IndexModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get; set; } = default!;


        public RestaurantIndexData RestaurantData { get; set; }
        public int RestaurantID { get; set; }
        public int BreakfastID { get; set; }
        public async Task OnGetAsync(int? id, int? breakfastID)
        {
            RestaurantData = new RestaurantIndexData();
            RestaurantData.Restaurants = await _context.Restaurant
             .Include(i => i.Breakfasts)
             .ThenInclude(c => c.Chef)
             .OrderBy(i => i.RestaurantName)
             .ToListAsync();
            if (id != null)
            {
                RestaurantID = id.Value;
                Restaurant restaurant = RestaurantData.Restaurants
                .Where(i => i.ID == id.Value).Single();
                RestaurantData.Breakfasts = restaurant.Breakfasts;
            }
        }
    }
}
