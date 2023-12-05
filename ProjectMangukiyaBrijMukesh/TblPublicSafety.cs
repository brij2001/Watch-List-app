using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblPublicSafety
{
    public int PsafetyId { get; set; }

    public string PGender { get; set; } = null!;

    public string Badge { get; set; } = null!;

    public string PName { get; set; } = null!;

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();
}
