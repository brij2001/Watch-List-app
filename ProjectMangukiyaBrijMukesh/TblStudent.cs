using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Major { get; set; }

    public int? CarId { get; set; }

    public virtual TblCar? Car { get; set; }

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();
}
