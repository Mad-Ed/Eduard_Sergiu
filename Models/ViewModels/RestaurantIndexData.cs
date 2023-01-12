using Eduard_Sergiu.Models;
using System.Security.Policy;

namespace Eduard_Sergiu.Models.ViewModels
{
    public class RestaurantIndexData
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Breakfast> Breakfasts { get; set; }

    }
}
