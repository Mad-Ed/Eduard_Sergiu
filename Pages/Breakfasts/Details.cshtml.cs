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
    public class DetailsModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public DetailsModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

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
    }
}
