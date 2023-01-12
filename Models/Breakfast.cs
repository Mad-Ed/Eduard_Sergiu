using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Eduard_Sergiu.Models
{
    public class Breakfast
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(6, 2)") ][Range(0.01, 500)]

        public decimal Price { get; set; }
        public int? RestaurantID { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int? ChefID { get; set; }
        public Chef? Chef { get; set; }
        public ICollection<FoodCategory>? FoodCategories { get; set; }
    }
}
