using AutoMapper;
using CodingSoldier.Core.Entities;
using CodingSoldier.Models;

namespace CodingSoldier.App_Start
{
    public class AutoMapperConfig
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(mapperConfiguration =>
            {
                mapperConfiguration.CreateMap<Post, PostViewModel>().ReverseMap();
                mapperConfiguration.CreateMap<Study, StudyViewModel>().ReverseMap();
                //mapperConfiguration.CreateMap<PaginatedList<Post>, PaginatedList<PostViewModel>>().ReverseMap();
                //mapperConfiguration.CreateMap<PaginatedList<Study>, PaginatedList<StudyViewModel>>().ReverseMap();
                mapperConfiguration.CreateMap<Post, PostApiEntity>().ReverseMap();
                mapperConfiguration.CreateMap<Study, StudyApiEntity>().ReverseMap();
            });
        }
    }
}
