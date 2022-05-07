namespace FanSite.Services.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }
        public int MediaId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
