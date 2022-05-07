using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSite.Services.Services
{
    public interface IMediaPictureService
    {
        Task<byte[]?> GetPicture(int id);

        Task<bool> DeletePicture(int id);

        Task<bool> UpdatePicture(int id, Stream stream);
    }
}
