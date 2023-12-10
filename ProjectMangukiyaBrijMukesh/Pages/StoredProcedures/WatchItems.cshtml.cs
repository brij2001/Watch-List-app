using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectMangukiyaBrijMukesh;

namespace ProjectMangukiyaBrijMukesh.Pages.StoredProcedures
{
    public class WatchItemsModel : PageModel
    {
        private readonly Bmangukiya1Context _context;
        public WatchItemsModel(Bmangukiya1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<spByWatchList> spByWatchList { get; set; } = default!;
        public async Task OnGetAsync(int ListId)
        {
            var listid = new Microsoft.Data.SqlClient.SqlParameter("@listid", ListId);
            //spByWatchList = await _context.spByWatchLists.FromSqlRaw("Exec spByWatchList @listid={0}", listid).ToListAsync();
        }
    }
}
