using FanSite.Services.Entities;

namespace FanSite.Services.Services
{
    public interface ICommentService
    {
        public IAsyncEnumerable<Comment> GetCommentsByMediaIdAsync(int mediaId);

        public Task<(int commentId, int mediaId, int userId)> CreateCommentAsync(Comment comment);
    }
}
