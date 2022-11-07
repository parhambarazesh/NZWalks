using AutoMapper;

namespace NZWalksApi.Profiles
{
    public class RegionsProfile:Profile
    {
        public RegionsProfile()
        {
            // Source -> Target
            // here we map Id from the source to Id from the target. ForMember is used to map the source to the target if the names are different.
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
            .ReverseMap();
            
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}