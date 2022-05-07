using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaTypeService : IMediaTypeService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public MediaTypeService(SiteContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MediaType?> GetMediaTypeById(int id)
        {
            var mediaTypeDto = await _context
                .MediaTypes
                .AsNoTracking()
                .Where(mediaType => mediaType.Id == id)
                .FirstOrDefaultAsync();
            if (mediaTypeDto is null)
            {
                return null;
            }

            return _mapper.Map<MediaType>(mediaTypeDto);
        }

        public async Task<bool> DeleteMediaType(int id)
        {
            var type = await _context
                .MediaTypes
                .Where(type => type.Id == id)
                .FirstOrDefaultAsync();

            if (type is null)
            {
                return false;
            }

            _context.MediaTypes.Remove(type);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CreateMediaType(MediaType mediaType)
        {
            ArgumentNullException.ThrowIfNull(mediaType);
            var dto = _mapper.Map<MediaTypeDto>(mediaType);
            await _context.MediaTypes.AddAsync(dto);
            await _context.SaveChangesAsync();
            return dto.Id;
        }
    }
}
