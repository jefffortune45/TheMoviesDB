using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using Image = System.Drawing.Image;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

using System.Drawing;

namespace TheMovies
{
    public partial class SplashScreen : System.Web.UI.Page
    {
        public static List<Film> Movies;
        public static SQLiteConnection connection ;

        public SplashScreen()
        {
            connection = CreateConnection();
            CreateTable(connection);
            if (Utilities.IsConnectedToInternet())
            {
                Console.WriteLine("No");

                Movies = Utilities.getMovieDbList();

                foreach (Film film in Movies)
                {
                    InsertData(connection, film);

                }
            }
            else
            {
                Console.WriteLine("Yes");
                Movies = GetData();
                 Console.WriteLine(value: Movies.ElementAt(0).title);

            }
           // InitializeComponent();
        }


       public static void CreateTable(SQLiteConnection conn)
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            string dataP = System.IO.Path.Combine(strWorkPath, "Film.db");
            string con = $"Data Source={dataP} version=3;";
            conn = new SQLiteConnection(con);
            conn.Open();

            string Createsql = "CREATE TABLE IF NOT EXISTS film1( id INT, original_title VARCHAR(20), overview VARCHAR, poster_path VARCHAR," +
                " release_date VARCHAR(20), original_language VARCHAR(20), popularity Float, title VARCHAR(20),video Bool, vote_average Float, vote_count INT,image BLOB )";

            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();


        }
        private void InsertData(SQLiteConnection conn, Film Movies)
        {
            byte[] pic = ImageToByteArray("https://image.tmdb.org/t/p/w342" + Movies.backdrop_path, System.Drawing.Imaging.ImageFormat.Jpeg);
            string txtSqlQuery = "INSERT INTO film1 (id, original_title, overview, poster_path, release_date," +
                " original_language, popularity, title, video,vote_average,vote_count,image) VALUES (@id, @original_title, @overview, @poster_path," +
                "@release_date, @original_language, @popularity, @title, @video, @vote_average, @vote_count,@pic);";

            SQLiteCommand command = new SQLiteCommand(txtSqlQuery, conn);
            command.Parameters.AddWithValue("@id", Movies.id);
            command.Parameters.AddWithValue("@original_title", Movies.original_title);
            command.Parameters.AddWithValue("@overview", Movies.overview);
            command.Parameters.AddWithValue("@poster_path", Movies.poster_path);
            command.Parameters.AddWithValue("@release_date", Movies.release_date);
            command.Parameters.AddWithValue("@original_language", Movies.original_language);
            command.Parameters.AddWithValue("@popularity", Movies.popularity);
            command.Parameters.AddWithValue("@title", Movies.title);
            command.Parameters.AddWithValue("@video", Movies.video);
            command.Parameters.AddWithValue("@vote_average", Movies.vote_average);
            command.Parameters.AddWithValue("@vote_count", Movies.vote_count);
            command.Parameters.AddWithValue("@pic", pic);

            command.ExecuteNonQuery();
        }



        public static SQLiteConnection CreateConnection()
        {
            string FilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string WorkPath = System.IO.Path.GetDirectoryName(FilePath);
            string database = System.IO.Path.Combine(WorkPath, "Film.db");
            string conne = $"Data Source={database} version=3;";


            // Create a new database connection:
            SQLiteConnection con = new SQLiteConnection(conne);
            // Open the connection:
            con.Open();

            return con;

        }
        public static List<Film> GetData()
        {
            List<Film> films = new List<Film>();
            SQLiteCommand cmd = new SQLiteCommand("Select * From film1", connection);

            SQLiteDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                Film film = new Film();
                film.id = rd.GetInt16(0);
                film.original_title = rd.GetString(1);
                film.overview = rd.GetString(2);
                film.poster_path = rd.GetString(3);
                film.release_date = rd.GetString(4);
                film.original_language = rd.GetString(5);
                film.popularity = rd.GetFloat(6);
                film.title = rd.GetString(7);
                film.video = rd.GetBoolean(8);
                film.vote_average = rd.GetFloat(9);
                film.vote_count = rd.GetInt16(10);
                byte[] image_byte = (byte[])rd["image"];
                 Image newImage = byteArrayToImage(image_byte);
                 film.image = newImage;
                 films.Add(film);
               

            }


            return films;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
         


        }
        /** public static byte[] ImageToByte(string backdrop, System.Drawing.Imaging.ImageFormat format)
         {
             WebClient client = new WebClient();
             Stream stream = client.OpenRead(backdrop);
             // Bitmap bitmap; 
             Image bitmap = new Bitmap(Image.FromStream(stream));

             using (MemoryStream ms = new MemoryStream())
             {
                 // Convert Image to byte[]
                 bitmap.Save(ms, format);
                 byte[] imageBytes = ms.ToArray();
                 return imageBytes;
             }

         } */

        public static byte[] ImageToByteArray(string backdrop, System.Drawing.Imaging.ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(backdrop);
            Image bitmap = new Bitmap(Image.FromStream(stream));

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }


        /* public static Image byteArrayToImage(byte[] bytesArr)
         {
             using (MemoryStream memstr = new MemoryStream(bytesArr))
             {
                 Image img = Image.FromStream(memstr);
                 return img;
             }
         }*/





        public static Image byteArrayToImage(byte[] bytesArr)
        {

            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
    }

   
}