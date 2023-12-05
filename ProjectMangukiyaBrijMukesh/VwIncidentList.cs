using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class VwIncidentList
{
    public DateOnly? IncidentDate { get; set; }

    public int? PoliceId { get; set; }

    public int? ViolationId { get; set; }

    public int? Driverid { get; set; }

    public string? Dname { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Dstate { get; set; }

    public int? Zip { get; set; }

    public string? Pname { get; set; }

    public int? Fine { get; set; }

    public string? Violation { get; set; }
}
