using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Eduard_Sergiu.Pages.Breakfasts
{
    [Authorize(Roles = "Admin")]

    public class EditModel : FoodCategoriesPageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public EditModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Breakfast Breakfast { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Breakfast == null)
            {
                return NotFound();
            }

            var breakfast =  await _context.Breakfast
                 .Include(b => b.Restaurant).Include(b => b.Chef)
 .Include(b => b.FoodCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (breakfast == null)
            {
                return NotFound();
            }



            
            Breakfast = breakfast;
            PopulateAssignedCategoryData(_context, Breakfast);



            ViewData["RestaurantID"] = new SelectList(_context.Set<Restaurant>(), "ID",
"RestaurantName");
            ViewData["ChefID"] = new SelectList(_context.Set<Chef>(), "ID",
"ChefName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var breakfastToUpdate = await _context.Breakfast
            .Include(i => i.Restaurant)
            .Include(i => i.Chef)
            .Include(i => i.FoodCategories)
            .ThenInclude(i => i.Category)
            
            .FirstOrDefaultAsync(s => s.ID == id);
            if (breakfastToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Breakfast>(
            breakfastToUpdate,
            "Breakfast",
            i => i.Title, i => i.Chef,
            i => i.Price, i => i.RestaurantID))
            {
                UpdateFoodCategories(_context, selectedCategories, breakfastToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateFoodCategories(_context, selectedCategories, breakfastToUpdate);
            PopulateAssignedCategoryData(_context, breakfastToUpdate);
            return Page();
        }
    }
}