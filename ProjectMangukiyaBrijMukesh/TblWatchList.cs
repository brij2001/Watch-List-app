using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblWatchList
{
    public int ListId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TblWatchListItem> TblWatchListItems { get; set; } = new List<TblWatchListItem>();
}
