using System;
using System.Collections.Generic;

namespace TravelPlanner.Entities;

public partial class Tripsdetail
{
    public int Userid { get; set; }

    public string? Originplace { get; set; }

    public DateOnly? Departureday { get; set; }

    public string? Destinationplace { get; set; }

    public DateOnly? Arrivalday { get; set; }

    public string? Modeoftransport { get; set; }

    public DateOnly? Durationoftrip { get; set; }

    public string? Addnotes { get; set; }

    public decimal? Budget { get; set; }

    public DateTime? Modifiedat { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<Membersdetail> Membersdetails { get; set; } = new List<Membersdetail>();

    public virtual ICollection<Placesdetail> Placesdetails { get; set; } = new List<Placesdetail>();
}
