using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblFaculty
{
    public int FacultyId { get; set; }

    public string FacName { get; set; } = null!;

    public string? FacGender { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? CarId { get; set; }

    public float? Salary { get; set; }

    public virtual TblCar? Car { get; set; }

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();
}
