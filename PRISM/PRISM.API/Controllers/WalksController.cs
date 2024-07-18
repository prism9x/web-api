using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRISM.API.CustomActionFilter;
using PRISM.API.Models.Domain;
using PRISM.API.Models.DTOs.Walk;
using PRISM.API.Repositories;

namespace PRISM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController(IWalkRepository repo, IMapper mapper) : ControllerBase
    {
        // /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walkDomainModel = await repo.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(mapper.Map<List<WalkDTO>>(walkDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await repo.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
            walkDomainModel = await repo.CreateAsync(walkDomainModel);
            var walkDto = mapper.Map<Walk>(walkDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);

            walkDomainModel = await repo.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            walkDomainModel.Name = updateWalkRequestDTO.Name;
            walkDomainModel.DifficultyId = updateWalkRequestDTO.DifficultyId;
            walkDomainModel.LengthInKm = updateWalkRequestDTO.LengthInKm;
            walkDomainModel.RegionId = updateWalkRequestDTO.RegionId;
            walkDomainModel.WalkImageUrl = updateWalkRequestDTO.WalkImageUrl;

            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await repo.DeleteAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
    }
}