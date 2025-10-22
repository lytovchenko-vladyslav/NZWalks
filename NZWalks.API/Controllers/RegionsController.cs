using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    // https://localhost:7083/api/regions
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(
            NZWalksDbContext dbContext,
            IRegionRepository regionRepository,
            IMapper mapper,
            ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        // GET:  https://localhost:7083/api/regions
        [HttpGet]
        [MapToApiVersion("1.0")]
        //TODO: Uncomment => [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAllV1()
        {
            logger.LogInformation("GetAll-Regions Action Method was Invoked");
            List<Region> regionsDomain = await regionRepository.GetAllAsync();

            logger.LogInformation($"Finished GetAll-Regions request with data: {JsonSerializer.Serialize(regionsDomain)}");
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAllV2()
        {
            logger.LogInformation("22222222222222222222222222222222222");
            List<Region> regionsDomain = await regionRepository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader,Writer")]
        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Region? regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null) { return NotFound(); }
            
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }


        // POST To Create a new Region
        // POST: https://localhost:7083/api/regions
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }


        // Update region
        // PUT: https://localhost:7083/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map Dto to Domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null) { return NotFound(); }

            var regionDto = mapper.Map<Region>(regionDomainModel);

            return Ok(regionDto);
        }


        // Update region
        // PUT: https://localhost:7083/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null) { return NotFound(); }

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
