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

namespace Eduard_Sergiu.Pages.Reservations
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public EditModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation =  await _context.Reservation.FirstOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }
            Reservation = reservation;
            ViewData["BreakfastID"] = new SelectList(_context.Breakfast, "ID", "Title");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(int id)
        {
          return _context.Reservation.Any(e => e.ID == id);
        }
    }
}
