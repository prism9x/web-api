﻿namespace PRISM.API.Models.DTOs.Region
{
    public class AddRegionRequestDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}