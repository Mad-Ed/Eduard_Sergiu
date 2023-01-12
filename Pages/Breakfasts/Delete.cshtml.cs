using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Eduard_Sergiu.Pages.Breakfasts
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public DeleteModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Breakfast Breakfast { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Breakfast == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfast.FirstOrDefaultAsync(m => m.ID == id);

            if (breakfast == null)
            {
                return NotFound();
            }
            else 
            {
                Breakfast = breakfast;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Breakfast == null)
            {
                return NotFound();
            }
            var breakfast = await _context.Breakfast.FindAsync(id);

            if (breakfast != null)
            {
                Breakfast = breakfast;
                _context.Breakfast.Remove(Breakfast);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
