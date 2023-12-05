using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProjectMangukiyaBrijMukesh.Pages
{
    public class watchlistModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;
        public watchlistModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }
        public IList<TblWatchList> watchlists { get; set; } = default!;
        public async Task OnGetAsync()
        {
            watchlists = await _context.TblWatchLists.ToListAsync();
        }
    }
}
