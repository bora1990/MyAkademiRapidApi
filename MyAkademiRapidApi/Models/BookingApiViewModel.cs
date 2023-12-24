namespace MyAkademiRapidApi.Models
{
    public class BookingApiViewModel
    {
        public Result[] result { get; set; }
        public class Result
        {
        
            public string district { get; set; }
            public string distance { get; set; }
            public string default_language { get; set; }          
            public string city { get; set; }
            public string main_photo_url { get; set; }
            public float min_total_price { get; set; }
         
            public string hotel_name { get; set; } 
            public float review_score { get; set; }
            public string address { get; set; }
        }
    }
}

