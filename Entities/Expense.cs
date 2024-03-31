using System;
using System.Collections.Generic;

namespace TravelPlanner.Entities;

public partial class Expense
{
    public int Expenseid { get; set; }

    public int? Userid { get; set; }

    public int? Placeid { get; set; }

    public string? Expensestype { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Modifiedat { get; set; }

    public virtual Placesdetail? Place { get; set; }

    public virtual Tripsdetail? User { get; set; }
}
