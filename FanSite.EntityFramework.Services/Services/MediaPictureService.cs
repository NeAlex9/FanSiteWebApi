using FanSite.EntityFramework.Services.Context;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaPictureService : IMediaPictureService
    {
        private readonly SiteContext _context;

        public MediaPictureService(SiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<byte[]?> GetPicture(int id)
        {
            var dto = await _context
                .Media
                .AsNoTracking()
                .Where(media => media.Id == id)
                .FirstOrDefaultAsync();
            if (dto is null || dto.Photo is null)
            {
                return null;
            }

            return dto.Photo;
        }

        public async Task<bool> DeletePicture(int id)
        {
            var dto = await _context
                .Media
                .Where(media => media.Id == id)
                .FirstOrDefaultAsync();
            if (dto is null)
            {
                return false;
            }

            dto.Photo = null;
            var updatedRows = await _context.SaveChangesAsync();
            return updatedRows > 0;
        }

        public async Task<bool> UpdatePicture(int id, Stream stream)
        {
            ArgumentNullException.ThrowIfNull(stream, nameof(stream));
            var dto = await _context
                .Media
                .Where(media => media.Id == id)
                .FirstOrDefaultAsync();
            if (dto is null)
            {
                return false;
            }
            
            await using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();
            dto.Photo = bytes;

            var updatedRows = await _context.SaveChangesAsync();
            return updatedRows > 0;
        }
    }
}
