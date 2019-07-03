using AutoMapper;
using CodingSoldier.Core.Entities;
using CodingSoldier.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, PostViewModel>()
                    .ForMember(p => p.PostContent, m => m.MapFrom(p => TweakPostContent(p)));
        CreateMap<PostViewModel, Post>();
        CreateMap<Study, StudyViewModel>().ReverseMap();
        //CreateMap<PaginatedList<Post>, PaginatedList<PostViewModel>>().ReverseMap();
        //CreateMap<PaginatedList<Study>, PaginatedList<StudyViewModel>>().ReverseMap();
        CreateMap<Post, PostApiEntity>().ReverseMap();
        CreateMap<Study, StudyApiEntity>().ReverseMap();
    }

    private string TweakPostContent(Post post)
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