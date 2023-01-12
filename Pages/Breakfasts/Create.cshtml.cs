using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;
using System.Security.Policy;
//using Eduard_Sergiu.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Eduard_Sergiu.Pages.Breakfasts
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : FoodCategoriesPageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public CreateModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RestaurantID"] = new SelectList(_context.Set<Restaurant>(), "ID",
"RestaurantName");
            ViewData["ChefID"] = new SelectList(_context.Set<Chef>(), "ID",
"ChefName");
            var breakfast = new Breakfast();
            breakfast.FoodCategories = new List<FoodCategory>();
            PopulateAssignedCategoryData(_context, breakfast);
            return Page();
        }

        [BindProperty]
        public Breakfast Breakfast { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBreakfast = new Breakfast();
            if (selectedCategories != null)
            {
                newBreakfast.FoodCategories = new List<FoodCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FoodCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBreakfast.FoodCategories.Add(catToAdd);
                }
            }
            Breakfast.FoodCategories = newBreakfast.FoodCategories;
            _context.Breakfast.Add(Breakfast);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newBreakfast);
            return Page();
        }

    }
}

