using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblIncident1
{
    public int IncidentId { get; set; }

    public DateOnly? IncidentDate { get; set; }

    public int? ViolationId { get; set; }

    public int? PoliceId { get; set; }

    public int? Driverid { get; set; }

    public virtual TblDriver? Driver { get; set; }

    public virtual TblPolice? Police { get; set; }

    public virtual TblViolation? Violation { get; set; }
}
