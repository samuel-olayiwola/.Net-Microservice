using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Mappings
{
    public class PlatformMapping: Profile
    {
        public PlatformMapping()
        {
            CreateMap<PlatformAddDto,Platform>().ReverseMap();
            CreateMap<PlatformResponseDto,Platform>().ReverseMap();
        }
    }
}
