using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eduard_Sergiu.Data;
using Eduard_Sergiu.Models;

namespace Eduard_Sergiu.Pages.Chefs
{
    public class IndexModel : PageModel
    {
        private readonly Eduard_Sergiu.Data.Eduard_SergiuContext _context;

        public IndexModel(Eduard_Sergiu.Data.Eduard_SergiuContext context)
        {
            _context = context;
        }

        public IList<Chef> Chef { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Chef != null)
            {
                Chef = await _context.Chef.ToListAsync();
            }
        }
    }
}
