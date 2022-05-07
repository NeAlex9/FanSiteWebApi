using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class CommentsService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly SiteContext _context;

        public CommentsService(IMapper mapper, SiteContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async IAsyncEnumerable<Comment> GetCommentsByMediaIdAsync(int mediaId)
        {
            await foreach (var comment in _context.Comments
                         .Include(comment => comment.User)
                         .AsNoTracking()
                         .Where(c => c.MediaId == mediaId)
                         .Select(dto =>
                             _mapper.Map<Comment>(dto))
                         .AsAsyncEnumerable())
            {
                yield return comment;
            }
        }

        public async Task<(int commentId, int mediaId, int userId)> CreateCommentAsync(Comment comment)
        {
            var dto = _mapper.Map<CommentDto>(comment);
            await _context.Comments.AddAsync(dto);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                throw new Exception("Cannot create comment");
            }

            return (dto.Id, dto.MediaId, dto.UserId);
        }
    }
}
