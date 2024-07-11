using AutoMapper;
using PRISM.API.Models.Domain;
using PRISM.API.Models.DTOs.Region;
using PRISM.API.Models.DTOs.Walk;

namespace PRISM.API.Mappings
{
    public class AutoMapProfiles : Profile
    {
        public AutoMapProfiles()
        {
            // Region
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();

            // Walk
            CreateMap<Walk, AddWalkRequestDTO>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
        }
    }
}