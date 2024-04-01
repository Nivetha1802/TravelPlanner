using System.ComponentModel.DataAnnotations;

namespace TravelPlanner
{
    public class tripdetailsdto
    {
        [Key]
        public string? Originplace { get; set; }

        public DateTime? Departureday { get; set; }

        public string? Destinationplace { get; set; }

        public DateTime? Arrivalday { get; set; }

        public string? Modeoftransport { get; set; }

        public DateTime? Durationoftrip { get; set; }

        public string? Addnotes { get; set; }

        public decimal? Budget { get; set; } = 0;

        public DateTime? Modifiedat { get; set; }
    }
}
