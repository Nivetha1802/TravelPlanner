using System.ComponentModel.DataAnnotations;

namespace TravelPlanner
{
    public class memberdetailsdto
    {
        
        /*public int? Userid { get; set; }*/
        [Key]
        public string? Membername { get; set; }

        public string? Membertype { get; set; }

        public int? Memberage { get; set; } = 0;
    }
}
