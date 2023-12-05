using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblPolice
{
    public int PoliceId { get; set; }

    public string? Pname { get; set; }

    public virtual ICollection<TblIncident1> TblIncident1s { get; set; } = new List<TblIncident1>();
}
