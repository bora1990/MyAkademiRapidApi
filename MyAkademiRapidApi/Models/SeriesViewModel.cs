namespace MyAkademiRapidApi.Models
{
    public class SeriesViewModel   //isimler harf kaçırmadan apiyle birebir aynı olmak zorundadır.
    {
        public int rank { get; set; }

        public string title { get; set; }

        public decimal rating { get; set; }

        public string image { get; set; }

        public string imdb_link { get; set; }
    }
}
