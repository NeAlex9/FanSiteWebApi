using AutoMapper;
using DomainEntities;
using FanSite.EntityFramework.Services.Entities;
using FanSite.Services.Entities;
using FanSiteService.Entities;

namespace FanSite.EntityFramework.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Media, MediaDto>().ReverseMap();
            CreateMap<MediaType, MediaTypeDto>().ReverseMap();
            CreateMap<MediaSeries, MediaSeriesDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }

}
