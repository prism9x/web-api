using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRISM.API.CustomActionFilter;
using PRISM.API.Models.Domain;
using PRISM.API.Models.DTOs.Region;
using PRISM.API.Repositories;

namespace PRISM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(
        IRegionRepository repo, 
        IMapper mapper, 
        ILogger<RegionsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                logger.LogInformation("GetAll Regions Action Method was invoked");
                // Get Data from Db
                var regionsDomain = await repo.GetAllAsync();

                logger.LogWarning("Finished GetAll Regions Action Method was invoked");

                return Ok(mapper.Map<List<RegionDTO>>(regionsDomain));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = _context.Regions.Find(id);
            var regionDomainModel = await repo.GetByIdAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);

            regionDomainModel = await repo.CreateAsync(regionDomainModel);
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            // Trả về HTTP 201 với URL của vùng mới tạo và chi tiết của vùng đó
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

            regionDomainModel = await repo.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            regionDomainModel.Code = updateRegionRequestDTO.Code;
            regionDomainModel.Name = updateRegionRequestDTO.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;

            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await repo.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }
    }
}