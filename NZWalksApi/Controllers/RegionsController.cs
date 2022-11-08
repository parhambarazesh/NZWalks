using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.DTO;
using NZWalksApi.Repositories;

namespace NZWalksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController:Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // var regions=new List<Region>(){
            //     new Region(){
            //         Id=Guid.NewGuid(),
            //         Code="AUK",
            //         Name="Auckland",
            //         Area=1.0,
            //         Lat=1.0,
            //         Long=1.0,
            //         Population=100000
            //     },
            //     new Region(){
            //         Id=Guid.NewGuid(),
            //         Code="WLG",
            //         Name="Wellington",
            //         Area=1.0,
            //         Lat=1.0,
            //         Long=1.0,
            //         Population=100000
            //     }
            // };
            // return regions model
            var regions=await _regionRepository.GetAllAsync();
            // return Ok(regions);

            // return DTO region: DTOs are used to expose only the data that is needed to the client. Then we can change the domain model without affecting the client.
            // var regionsDTO=new List<Models.DTO.Region>();
            // regions.ToList().ForEach(region=>{
            //     var regionDTO=new Models.DTO.Region(){
            //         Id=region.Id,
            //         Code=region.Code,
            //         Name=region.Name,
            //         Area=region.Area,
            //         Lat=region.Lat,
            //         Long=region.Long,
            //         Population=region.Population
            //     };
            //     regionsDTO.Add(regionDTO);
            // });
            // return Ok(regionsDTO);

            // return DTO region using AutoMapper
            var regionsDto=_mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDto);
        }

        [HttpGet("{id}")]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        // {id} is a placeholder for the id parameter and :guid is a constraint to ensure that the id is a guid
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region=await _regionRepository.GetAsync(id);
            if(region==null)
            {
                return NotFound();
            }
            var regionDTO=_mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            // Request(DTO) to Domain Model
            var region=new Models.Domain.Region(){
                Code=addRegionRequest.Code,
                Name=addRegionRequest.Name,
                Area=addRegionRequest.Area,
                Lat=addRegionRequest.Lat,
                Long=addRegionRequest.Long,
                Population=addRegionRequest.Population
            };
            // Pass details to Repository
            var newRegion=await _regionRepository.AddAsync(region);
            // Convert Domain Model to DTO
            var regionDTO=_mapper.Map<Models.DTO.Region>(newRegion);
            // var regionDTO=new Models.DTO.Region(){
            //     Id=newRegion.Id,
            //     Code=newRegion.Code,
            //     Name=newRegion.Name,
            //     Area=newRegion.Area,
            //     Lat=newRegion.Lat,
            //     Long=newRegion.Long,
            //     Population=newRegion.Population
            // };

            //  with CreatedAtAction, the client will receive a 201 status code and the Location header will be set to the URL of the newly created resource
            return CreatedAtAction(nameof(GetRegionAsync),new {id=regionDTO.Id},regionDTO);
        }
    }
}