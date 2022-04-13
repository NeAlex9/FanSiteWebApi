using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainEntities;
using FanSite.Services.Services;
using FanSiteService.Context;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaService : IMediaService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public MediaService(SiteContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async IAsyncEnumerable<Media> GetMedia(int offset, int limit)
        {
            await foreach (var media in _context
                               .Media
                               .AsNoTracking()
                               .Take(limit)
                               .Skip(offset)
                               .AsAsyncEnumerable())
            {
                yield return _mapper.Map<Media>(media);
            }
        }

        public Task<Media> GetMediaById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetMediaLength() =>
            await _context
                .Media
                .AsNoTracking()
                .CountAsync();

        public Task<bool> UpdateMedia(int id, Media media)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMedia(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Media> CreateMedia(Media media)
        {
            throw new NotImplementedException();
        }
    }
}
