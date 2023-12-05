using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace ProjectMangukiyaBrijMukesh.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PopularService _popularService;
        public List<PopularModel> Popular { get; set; }
        public IndexModel()
        {
            _popularService = new PopularService();
        }
        public async Task OnGetAsync()
        {
            Popular = await _popularService.GetPopular();
        }
    }
}
