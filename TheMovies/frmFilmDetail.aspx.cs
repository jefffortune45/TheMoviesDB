using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheMovies
{
    public partial class frmFilmDetail : System.Web.UI.Page
    {
        public static int index = 0;
        public FormFilm mainForm;
        private Film currentFilm;
        public const String VIDEO_URL = "https://api.themoviedb.org/3/movie/{0}/videos?api_key=a07e22bc18f5cb106bfe4cc1f83ad8ed";
        public static List<Film> Movies = FormFilm.Movies;
        protected void Page_Load(object sender, EventArgs e)
        {
              currentFilm =  FormFilm.currentFilm;
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='600' height='300' frameborder='0' allowfullscreen></iframe>";
            html += "</body></html>";
            this.Video.Text = string.Format(html, getYoutubeKey());
            display(FormFilm.Index());

        }
        private String getYoutubeKey()
        {

            String reponse = "";
            String youtubeKey = "";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    reponse = webClient.DownloadString(String.Format(VIDEO_URL, currentFilm.id));
                }

                using (JsonDocument document = JsonDocument.Parse(reponse))
                {
                    JsonElement root = document.RootElement;
                    JsonElement resultsList = root.GetProperty("results");

                    int i = 0;
                    while (true)
                    {
                        String type = resultsList[i].GetProperty("type").ToString();
                        youtubeKey = resultsList[i].GetProperty("key").ToString();
                        if (type.Equals("Clip"))
                        {
                            break;
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return youtubeKey;
        }
        public void display(int index)
        {
            Film film = Movies.ElementAt(index);
            lblTitle.Text = film.title.ToUpper();
            overview.Text = film.overview;
            language.Text = film.original_language;
            date.Text = film.release_date;
            popularity.Text = Convert.ToString(film.popularity);
            Vote_average.Text = Convert.ToString(film.vote_average);
            vote_count.Text = Convert.ToString(film.vote_count);
        }
    }
}