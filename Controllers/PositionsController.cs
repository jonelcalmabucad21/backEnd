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
    public class PositionsController : Controller
    {
        
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;
        

        public PositionsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var count = await _unitofWork.PositionRepository.GetCount();
            var positions = await _unitofWork.PositionRepository.GetAll();

            var response = new { 
                count,
                positions = Mapper.Map<IEnumerable<Position>, IEnumerable<PositionDTO>>(positions)
            };
            return Ok(response);
        }
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var count = await _unitofWork.PositionRepository.GetCount();
            var positions = await _unitofWork.PositionRepository.GetAll(pageIndex,pageSize);

            var response = new { 
                count,
                positions = Mapper.Map<IEnumerable<Position>, IEnumerable<PositionDTO>>(positions) 
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PositionDTO positionDTO)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var position = Mapper.Map<PositionDTO, Position>(positionDTO);

            await _unitofWork.PositionRepository.AddAsync(position);
            await _unitofWork.Commit();

            position = await _unitofWork.PositionRepository.SingleOrDefault(p => p.Id == position.Id);
            
            return Ok(Mapper.Map<Position, PositionDTO>(position));       
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]PositionDTO positionDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);    
        
            var positioninDb = await _unitofWork.PositionRepository.SingleOrDefault(p => p.Id == id);

            if(positioninDb == null)
                return NotFound();

            Mapper.Map<PositionDTO, Position>(positionDTO,  positioninDb);
            
            await _unitofWork.Commit();

            var result = Mapper.Map<Position, PositionDTO>(positioninDb);

            return Ok(result);                  
        }
    }
}