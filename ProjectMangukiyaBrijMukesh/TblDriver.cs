using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblDriver
{
    public int Driverid { get; set; }

    public string? Dname { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Dstate { get; set; }

    public int? Zip { get; set; }

    public virtual ICollection<TblIncident1> TblIncident1s { get; set; } = new List<TblIncident1>();
}
