using PRISM.API.Models.DTOs.Difficulty;
using PRISM.API.Models.DTOs.Region;

namespace PRISM.API.Models.DTOs.Walk
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }

        //public Guid DifficultyId { get; set; }
        //public Guid RegionId { get; set; }

        // Include thông tin 2 bảng này vào
        public RegionDTO Region { get; set; }

        public DifficultyDTO Difficulty { get; set; }
    }
}