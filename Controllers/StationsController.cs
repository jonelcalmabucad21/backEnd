using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backEnd.Controllers.DataTransferObjects;
using backEnd.Models;
using backEnd.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;
        

        public StationsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var count = await _unitofWork.StationRepository.GetCount();
            var stations = await _unitofWork.StationRepository.GetAll();

            var response = new { 
                count,
                stations = Mapper.Map<IEnumerable<Station>, IEnumerable<StationDTO>>(stations)
            };
            return Ok(response);
        }
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var count = await _unitofWork.StationRepository.GetCount();
            var stations = await _unitofWork.StationRepository.GetAll(pageIndex,pageSize);

            var response = new { 
                count,
                stations = Mapper.Map<IEnumerable<Station>, IEnumerable<StationDTO>>(stations)
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StationDTO stationDTO)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var station = Mapper.Map<StationDTO, Station>(stationDTO);

            await _unitofWork.StationRepository.AddAsync(station);
            await _unitofWork.Commit();

            station = await _unitofWork.StationRepository.SingleOrDefault(p => p.Id == station.Id);
            
            return Ok(Mapper.Map<Station, StationDTO>(station));       
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]StationDTO stationDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);    
        
            var stationinDb = await _unitofWork.StationRepository.SingleOrDefault(p => p.Id == id);

            if(stationinDb == null)
                return NotFound();

            Mapper.Map<StationDTO, Station>(stationDTO,  stationinDb);
            
            await _unitofWork.Commit();

            var result = Mapper.Map<Station, Station>(stationinDb);

            return Ok(result);                  
        }
    }
}