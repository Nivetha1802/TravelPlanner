namespace TravelPlanner
{
    public class expensesdto
    {
        public int? Userid { get; set; }

        public int? Placeid { get; set; }
     
        public string? Expensestype { get; set; }

        public decimal? Amount { get; set; } = 0;
    }
}
