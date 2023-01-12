using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Eduard_Sergiu.Pages.Reservations
{
    
    public class CreateModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public CreateModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var breakfastList = _context.Breakfast
 .Include(b => b.Chef)
 .Select(x => new
 {
     x.ID,
     BreakfastFullName = x.Title + " - " + x.Chef.ChefName
 });

            ViewData["BreakfastID"] = new SelectList(breakfastList, "ID",
            "BreakfastFullName");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID",
           "FullName");

            
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
