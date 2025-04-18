using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.TvShows;

namespace ProjectMangukiyaBrijMukesh
{
    public class detailsModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;
        public detailsModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }
        public SelectList watchlists { get; set; } = default!;
        public TblWatchListItem TblWatchListItem { get; set; } = default!;

        public async Task OnGetAsync(string type, string id)
        {
            var a = ApiAccess.ApiKey;
            TMDbClient client = new TMDbClient(a);
            TMDbConfig config = client.GetConfigAsync().Result;
            //System.Diagnostics.Debug.WriteLine(type + id);

            if (type == "tv" || type == "TV Show")
            {
                int id1 = Convert.ToInt32(id);
                TvShow show = await client.GetTvShowAsync(id1, TvShowMethods.Images | TvShowMethods.Videos);
                ViewData["MediaId"] = show.Id;
                ViewData["Title"] = show.Name;
                ViewData["GenreId"] = show.Genres[0].Id;
                try { ViewData["backdrop"] = client.GetImageUrl("original", show.Images.Backdrops[0].FilePath); }
                catch { ViewData["backdrop"] = client.GetImageUrl("original", show.Images.Posters[0].FilePath); }
                ViewData["Poster"] = client.GetImageUrl("original", show.Images.Posters[0].FilePath).ToString();
                ViewData["Overview"] = show.Overview;
                try { ViewData["ReleaseDate"] = show.FirstAirDate.Value.ToString("d"); }
                catch { ViewData["ReleaseDate"] = "Not yet released"; }
                try { ViewData["Runtime"] = show.EpisodeRunTime[0]; }
                catch { ViewData["Runtime"] = "N/A"; }
                ViewData["ImdbLink"] = "N/A";
                ViewData["Type"] = "TV Show";
                Random random = new Random();
                for (int i = 0; i < show.Videos.Results.Count; i++)
                {
                    if (show.Videos.Results[i].Site != "YouTube")
                    {
                        show.Videos.Results.RemoveAt(i);
                    }
                }
                ViewData["trailer"] = show.Videos.Results[random.Next(show.Videos.Results.Count)].Key;
                System.Diagnostics.Debug.WriteLine(ViewData["trailer"]);
            }
            else if (type == "movie" || type == "Movie")
            {
                Movie movie = await client.GetMovieAsync(id, MovieMethods.Images | MovieMethods.Videos);
                ViewData["MediaId"] = movie.Id;
                ViewData["GenreId"] = movie.Genres[0].Id;
                ViewData["Title"] = movie.Title;
                try { ViewData["backdrop"] = client.GetImageUrl("original", movie.Images.Backdrops[0].FilePath); }
                catch { ViewData["backdrop"] = client.GetImageUrl("original", movie.Images.Posters[0].FilePath); }
                ViewData["Poster"] = client.GetImageUrl("original", movie.Images.Posters[0].FilePath).ToString();
                ViewData["Overview"] = movie.Overview;
                try { ViewData["ReleaseDate"] = movie.ReleaseDate.Value.ToString("d"); }
                catch { ViewData["ReleaseDate"] = "N/A"; }
                ViewData["Runtime"] = movie.Runtime;
                ViewData["ImdbLink"] = "https://www.imdb.com/title/" + movie.ImdbId;
                ViewData["Type"] = "Movie";
                ViewData["trailer"] = movie.Videos.Results[0].Key;
            }
            watchlists = new SelectList(_context.TblWatchLists, "ListId", "Name");

        }

        public async Task<IActionResult> OnPostAsync()
        {
            string mediaId = Request.Form["id"].ToString();
            string Listid = Request.Form["selected"].ToString();
            TblWatchListItem = new TblWatchListItem();
            TblWatchListItem.Title = Request.Form["title"].ToString();
            TblWatchListItem.Poster = Request.Form["poster"].ToString();
            TblWatchListItem.ListId = Convert.ToInt32(Listid);
            TblWatchListItem.MediaId = Request.Form["id"].ToString();
            //System.Diagnostics.Debug.WriteLine(Request.Form["genreid"]);
            TblWatchListItem.GenreId = Convert.ToInt32(Request.Form["genreid"]);
            TblWatchListItem.MediaType = Request.Form["mediaType"].ToString();
            TblWatchListItem.Description = Request.Form["overview"].ToString(); ;
            TblWatchListItem.AddedDate = DateOnly.FromDateTime(DateTime.Now);

            if (_context.TblWatchListItems.Where(x => x.MediaId == mediaId && x.ListId == Convert.ToInt32(Listid)).ToList().Count > 0)
            {
                System.Diagnostics.Debug.WriteLine("Already in watchlist");
                return Redirect($"/watchListDetails/?id={TblWatchListItem.ListId}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Not in watchlist");
                _context.TblWatchListItems.Add(TblWatchListItem);
                await _context.SaveChangesAsync();
            }
            return Redirect($"/watchListDetails/?id={TblWatchListItem.ListId}");
        }
    }
}
