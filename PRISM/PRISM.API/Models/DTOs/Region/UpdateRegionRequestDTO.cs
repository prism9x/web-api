namespace PRISM.API.Models.DTOs.Region
{
    public class UpdateRegionRequestDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}