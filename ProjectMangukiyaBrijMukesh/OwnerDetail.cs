using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class OwnerDetail
{
    public short OwnerId { get; set; }

    public string OwnerLastName { get; set; } = null!;

    public string OwnerFirstName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Town { get; set; }

    public string? State { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<PetDetail> PetDetails { get; set; } = new List<PetDetail>();
}
