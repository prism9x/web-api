﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRISM.API.Models.Domain;
using PRISM.API.Models.DTOs.Walk;
using PRISM.API.Repositories;

namespace PRISM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController(IWalkRepository repo, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
            walkDomainModel = await repo.CreateAsync(walkDomainModel);
            var walkDto = mapper.Map<Walk>(walkDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDomainModel = await repo.GetAllAsync();
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

        [HttpPut]
        [Route("{id:Guid}")]
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
    }
}