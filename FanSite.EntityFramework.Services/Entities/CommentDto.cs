using DomainEntities;

namespace FanSiteService.Entities
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }
        public int MediaId { get; set; }
        public int UserId { get; set; }

        public MediaDto Media { get; set; }
        public User User { get; set; }
    }
}
