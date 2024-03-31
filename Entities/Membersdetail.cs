using System;
using System.Collections.Generic;

namespace TravelPlanner.Entities;

public partial class Membersdetail
{
    public int Memberid { get; set; }

    public int? Userid { get; set; }

    public string? Membername { get; set; }

    public string? Membertype { get; set; }

    public int? Memberage { get; set; }

    public DateTime? Modifiedat { get; set; }

    public virtual Tripsdetail? User { get; set; }
}
