using System.ComponentModel.DataAnnotations;

namespace TravelPlanner
{
    public class expensesdto
    {
        [Key]
        public int? Userid { get; set; }

        public int? Placeid { get; set; }

        public string? Expensestype { get; set; }

        public decimal? Amount { get; set; } = 0;
    }
}
