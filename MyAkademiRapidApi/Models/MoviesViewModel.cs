namespace MyAkademiRapidApi.Models
{
    public class MoviesViewModel
    {


        public int rank { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public string[] genre { get; set; }  //tür

        public string rating { get; set; }

        public int year { get; set; }



        public string imdb_link { get; set; }


    }
}
