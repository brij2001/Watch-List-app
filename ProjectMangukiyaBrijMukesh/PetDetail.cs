using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class PetDetail
{
    public short PetId { get; set; }

    public string PetName { get; set; } = null!;

    public string? Type { get; set; }

    public string? Breed { get; set; }

    public string? Sex { get; set; }

    public DateOnly? Dob { get; set; }

    public float? Price { get; set; }

    public string? PetNotes { get; set; }

    public short? OwnerId { get; set; }

    public virtual OwnerDetail? Owner { get; set; }
}
