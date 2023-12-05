using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.TvShows;

namespace ProjectMangukiyaBrijMukesh.Pages
{
    public class detailsModel : PageModel
    {
        public async Task OnGetAsync(string type, string id)
        {
            var a = ApiAccess.ApiKey;
            TMDbClient client = new TMDbClient(a);
            TMDbConfig config = client.GetConfigAsync().Result;
            //System.Diagnostics.Debug.WriteLine(type + id);

            if (type == "tv")
            {
                int id1 = Convert.ToInt32(id);
                TvShow show = await client.GetTvShowAsync(id1, TvShowMethods.Images);
                ViewData["Title"] = show.Name;
                ViewData["Poster"] = client.GetImageUrl("original", show.Images.Posters[0].FilePath).ToString();
                ViewData["Overview"] = show.Overview;
                ViewData["ReleaseDate"] = show.FirstAirDate.Value.ToString("d");
                try { ViewData["Runtime"] = show.EpisodeRunTime[0]; }
                catch { ViewData["Runtime"] = "N/A"; }
                try
                {
                    ViewData["ImdbLink"] = "https://www.imdb.com/title/" + show.ExternalIds.ImdbId;
                }
                catch { ViewData["ImdbLink"] = "N/A"; }
                ViewData["Type"] = "TV Show";
            }
            else if (type == "movie")
            {
                Movie movie = await client.GetMovieAsync(id, MovieMethods.Images);
                ViewData["Title"] = movie.Title;
                ViewData["Poster"] = client.GetImageUrl("original", movie.Images.Posters[0].FilePath).ToString();
                ViewData["Overview"] = movie.Overview;
                ViewData["ReleaseDate"] = movie.ReleaseDate.Value.ToString("d");
                ViewData["Runtime"] = movie.Runtime;
                ViewData["ImdbLink"] = "https://www.imdb.com/title/" + movie.ImdbId;
                ViewData["Type"] = "Movie";
            }

        }
    }
}
