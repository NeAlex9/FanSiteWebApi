namespace FanSiteWebApi.Model.Comment
{
    public class CommentToCreate
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public string Text { get; set; }
    }
}
