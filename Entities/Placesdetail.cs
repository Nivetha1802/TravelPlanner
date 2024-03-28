using System;
using System.Collections.Generic;

namespace TravelPlanner.Entities;

public partial class Placesdetail
{
    public int Placeid { get; set; }

    public int? Userid { get; set; }

    public string? Placename { get; set; }

    public string? Notes { get; set; }

    public DateTime? Modifiedat { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual Tripdetail? User { get; set; }
}
