using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainEntities;
using FanSite.EntityFramework.Services.Entities;
using FanSiteService.Entities;

namespace FanSite.EntityFramework.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Comment, CommentDto>().ReverseMap();
            this.CreateMap<Media, MediaDto>().ReverseMap();
        }
    }

}
