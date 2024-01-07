namespace MyAkademiRapidApi.Models
{
    public class OtelVeriViewModel
    {
        public int Count { get; set; }
        public MapPageFields MapPageFields { get; set; }
        public List<Result> Results { get; set; }


    }

    public class PropertyAnnotation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class BoundingBox
    {
        public double SwLat { get; set; }
        public double SwLon { get; set; }
        public double NeLon { get; set; }
        public double NeLat { get; set; }
    }

    public class MapPageFields
    {
        public List<PropertyAnnotation> PropertyAnnotations { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }

    public class GrossPrice
    {
        public string Currency { get; set; }
        public double Value { get; set; }
    }

    public class PriceBreakdown
    {
        public List<object> BenefitBadges { get; set; }
        public List<object> TaxExceptions { get; set; }
        public GrossPrice GrossPrice { get; set; }
        public GrossPrice ExcludedPrice { get; set; }
        public GrossPrice StrikethroughPrice { get; set; }
    }

    public class Checkin
    {
        public string UntilTime { get; set; }
        public string FromTime { get; set; }
    }

    public class Checkout
    {
        public string FromTime { get; set; }
        public string UntilTime { get; set; }
    }
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MainPhotoId { get; set; }
        public string PhotoMainUrl { get; set; }
        public List<string> PhotoUrls { get; set; }
        public int Position { get; set; }
        public int RankingPosition { get; set; }
        public string CountryCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PriceBreakdown PriceBreakdown { get; set; }
        public string Currency { get; set; }
        public Checkin Checkin { get; set; }
        public Checkout Checkout { get; set; }
        public string CheckoutDate { get; set; }
        public string CheckinDate { get; set; }
        public double ReviewScore { get; set; }
        public string ReviewScoreWord { get; set; }
        public int ReviewCount { get; set; }
        public int QualityClass { get; set; }
        public bool IsFirstPage { get; set; }
        public int AccuratePropertyClass { get; set; }
        public int PropertyClass { get; set; }
        public int Ufi { get; set; }
        public string WishlistName { get; set; }
        public int OptOutFromGalleryChanges { get; set; }
    }

}
