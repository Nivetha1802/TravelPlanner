using System.ComponentModel.DataAnnotations;

namespace TravelPlanner
{
    public class placesdetailsdto
    {

        /*public int? Userid { get; set; }*/
        [Key]
        public string? Placename { get; set; }

        public string? Notes { get; set; } = null;
    }
}
