using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using FanSite.Services.Entities;
using FanSite.Services.Services.MediaSelector;

namespace FanSite.EntityFramework.Services.Services
{
    public class MediaSelectorService : IMediaSelectorService
    {
        public bool Verify(Media media, Query query) =>
            VerifyType(media.Type.Name, query.Type) && VerifyUpcoming(media.IsUpcoming, query.Upcoming);

        protected virtual bool VerifyType(string verifiedType, MediaTypeEnum type) =>
            type is MediaTypeEnum.None || type.ToString() == verifiedType;
        

        protected virtual bool VerifyUpcoming(bool isUpcoming, UpcomingEnum upcoming) =>
            upcoming is UpcomingEnum.None || upcoming.ToString() == isUpcoming.ToString();
        
    }
}
