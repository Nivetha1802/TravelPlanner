namespace TravelPlanner
{
    public class tripdetailsdto
    {
        public string? Originplace { get; set; }

        public DateOnly? Departureday { get; set; }

        public string? Destinationplace { get; set; }

        public DateOnly? Arrivalday { get; set; }

        public string? Modeoftransport { get; set; }

        public DateOnly? Durationoftrip { get; set; }

        public string? Addnotes { get; set; }

        public decimal? Budget { get; set; } = 0;
    }
}
