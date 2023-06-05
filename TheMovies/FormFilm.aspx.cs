 using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace TheMovies
{
    public partial class FormFilm : System.Web.UI.Page

    {
        public static Film currentFilm;
        public static int index = 0;
        public  FormFilm mainForm;
        public static List<Film>  Movies ;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SplashScreen.CreateTable(SplashScreen.CreateConnection());
            if (Utilities.IsConnectedToInternet())
            {
                Movies = Utilities.getMovieDbList();
                // Afficher le panel en vert si il y a de l'internet 
                Panel1.BackColor = Color.Green;
            }
            else
            {
                // Afficher le panel en rouge si il n'y a de l'internet 
                Panel1.BackColor = Color.Red;
                Movies = SplashScreen.GetData();
            }
            display(index);
        }

        protected void Pic_Click1(object sender, ImageClickEventArgs e)
        {
            frmFilmDetail form = new frmFilmDetail();
           // form.Show();
           // form.mainForm = this;
          //  this.Hide();

        }
        public static int Index()
        {
            return index;
        }
        public void display(int Movie)
        {
            if (Movie < 0 || Movie == SplashScreen.Movies.Count)
            {
                MessageBox.Show("No Movie");
                return;
            }
            if (Utilities.IsConnectedToInternet())
            {
                Film film = SplashScreen.Movies.ElementAt(Movie);
                Title.Text = film.title;
                overview.Text = film.overview;
                Releasedate.Text = film.release_date;
              
                ImageButton1.ImageUrl = "https://image.tmdb.org/t/p/w500" + film.poster_path;
                currentFilm = film;

            }
            else
            {
               

        Film film = SplashScreen.Movies.ElementAt(Movie);
                Title.Text = film.title;
                overview.Text = film.overview;
               
                currentFilm = film;
            }


        }

        protected void Precedent_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                display(index);


            }
        }

        protected void Suivant_Click(object sender, EventArgs e)
        {

            index++;
            display(index);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmFilmDetail.aspx");

        }
    }
}