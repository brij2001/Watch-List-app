using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblGenre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblWatchListItem> TblWatchListItems { get; set; } = new List<TblWatchListItem>();
}
