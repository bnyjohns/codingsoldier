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
                mapperConfiguration.CreateMap<Post, PostViewModel>()
                    .ForMember(p => p.PostContent, m => m.MapFrom(p => TweakPostContent(p)));
                mapperConfiguration.CreateMap<PostViewModel, Post>();
                mapperConfiguration.CreateMap<Study, StudyViewModel>().ReverseMap();
                //mapperConfiguration.CreateMap<PaginatedList<Post>, PaginatedList<PostViewModel>>().ReverseMap();
                //mapperConfiguration.CreateMap<PaginatedList<Study>, PaginatedList<StudyViewModel>>().ReverseMap();
                mapperConfiguration.CreateMap<Post, PostApiEntity>().ReverseMap();
                mapperConfiguration.CreateMap<Study, StudyApiEntity>().ReverseMap();
            });
        }

        private static string TweakPostContent(Post post)
        {
            if (string.IsNullOrEmpty(post.PostContent) || string.IsNullOrEmpty(post.PostUrl))
                return post.PostContent;

            var subStringLength = 700;
            while (post.PostContent.Length < subStringLength)
                subStringLength -= 20;

            var result = post.PostContent.Substring(0, subStringLength);
            result += $"<a target='_blank' href={post.PostUrl}>....</a>";
            return result;
        }
    }
}
