using System.ComponentModel.DataAnnotations;

namespace PRISM.API.Models.DTOs.Region
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to me a minium of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to me a maxium of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to me a maxium of 3 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}