using System.ComponentModel.DataAnnotations;

namespace Eduard_Sergiu.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public int? BreakfastID { get; set; }
        public Breakfast? Breakfast { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
    }
}
