using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eduard_Sergiu.Models;

namespace Eduard_Sergiu.Data
{
    public class Eduard_SergiuContext : DbContext
    {
        public Eduard_SergiuContext (DbContextOptions<Eduard_SergiuContext> options)
            : base(options)
        {
        }

        public DbSet<Eduard_Sergiu.Models.Breakfast> Breakfast { get; set; } = default!;

        public DbSet<Eduard_Sergiu.Models.Restaurant> Restaurant { get; set; }

        public DbSet<Eduard_Sergiu.Models.Chef> Chef { get; set; }

        public DbSet<Eduard_Sergiu.Models.Category> Category { get; set; }

        public DbSet<Eduard_Sergiu.Models.Customer> Customer { get; set; }

        public DbSet<Eduard_Sergiu.Models.Reservation> Reservation { get; set; }
    }
}
