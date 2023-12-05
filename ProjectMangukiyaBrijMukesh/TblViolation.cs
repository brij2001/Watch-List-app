using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblViolation
{
    public int ViolationId { get; set; }

    public string? Violation { get; set; }

    public int? Fine { get; set; }

    public virtual ICollection<TblIncident1> TblIncident1s { get; set; } = new List<TblIncident1>();
}
