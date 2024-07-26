using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repository;
using PlatformService.Dtos;
using PlatformService.HttpClients;
using PlatformService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICommandHttpClient _commandHttpClient;

        public PlatformController(IPlatformRepository platformRepository, IMapper mapper, ICommandHttpClient commandHttpClient)
        {
            _repository = platformRepository;
            _mapper = mapper;
            _commandHttpClient = commandHttpClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformResponseDto>> GetPlatforms()
        {
            var platformList =  _repository.GetAllPlatforms();
            var mappedList = _mapper.Map<IEnumerable<PlatformResponseDto>>(platformList);
            return Ok(mappedList);
        }

        [HttpGet("{id}")]
        public ActionResult<PlatformResponseDto> GetPlatformById(int id)
        {
            var platform = _repository.GetPlatformById(id);
            
            if (platform == null)
            {
                return NotFound();
            }
            
            var mappedItem = _mapper.Map<PlatformResponseDto>(platform);
            return Ok(mappedItem);
        }

        [HttpPost]
        public async Task<ActionResult<PlatformResponseDto>> AddPlatform([FromBody] PlatformAddDto request)
        {
            var objToCreate = _mapper.Map<Platform>(request);
            var resp = _repository.AddPlatform(objToCreate);
            _repository.saveChanges();
            var mappedResp = _mapper.Map<PlatformResponseDto>(resp);

            try
            {
                await _commandHttpClient.SendCommand(mappedResp);
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while sending command : {ex.Message}");
            }

            return Created(nameof(GetPlatformById),mappedResp);

        }
    }
}
