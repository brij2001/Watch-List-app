using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblCar
{
    public int CarId { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? CarYear { get; set; }

    public string? Color { get; set; }

    public string? LicensePlate { get; set; }

    public float? Cost { get; set; }

    public virtual ICollection<TblFaculty> TblFaculties { get; set; } = new List<TblFaculty>();

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();
}
