namespace FanSite.Services.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public MediaType Type { get; set; }
        public double Rating { get; set; }
        public MediaSeries Series { get; set; }
        public bool IsUpcoming { get; set; }
    }
}
