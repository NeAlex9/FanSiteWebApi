using AutoMapper;
using FanSite.Services.Entities;
using FanSiteWebApi.Model.Comment;

namespace FanSiteWebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Comment, CommentToCreate>().ReverseMap();
        }
    }
}
