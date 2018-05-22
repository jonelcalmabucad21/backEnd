using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backEnd.Controllers.DataTransferObjects;
using backEnd.Models;
using backEnd.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    public class LevelSectionsController : Controller
    {
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;

        public LevelSectionsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;
        }     

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int count = await _unitofWork.LevelSectionRepository.GetCount();
            var levelSections = await _unitofWork.LevelSectionRepository.GetAll();

            var response = new {
                count,
                levelSections = Mapper.Map<IEnumerable<LevelSection>, IEnumerable<LevelSectionDTO>>(levelSections)
            };
            return Ok(response);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            int count = await _unitofWork.LevelSectionRepository.GetCount();
            var levelSections = await _unitofWork.LevelSectionRepository.GetAll(pageIndex,pageSize);

            var response = new {
                count,
                levelSections = Mapper.Map<IEnumerable<LevelSection>, IEnumerable<LevelSectionDTO>>(levelSections)
            };

            return Ok(response);
        }
        
        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> Get(int employeeId)
        {
            var levelSections = await _unitofWork.LevelSectionRepository.GetAll(p => p.SectionAdviser.Adviser.Employee.Id == employeeId && p.SchoolYear == 2017);
            return Ok(Mapper.Map<IEnumerable<LevelSection>, IEnumerable<LevelSectionDTO>>(levelSections));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LevelSectionDTO LevelSectionDTO)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var levelSection = Mapper.Map<LevelSectionDTO, LevelSection>(LevelSectionDTO);

            await _unitofWork.LevelSectionRepository.AddAsync(levelSection);
            await _unitofWork.Commit();

            levelSection = await _unitofWork.LevelSectionRepository.SingleOrDefault(p => p.Id == levelSection.Id);
            
            return Ok(Mapper.Map<LevelSection, LevelSectionDTO>(levelSection));       
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]LevelSection levelSectionDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);    
        
            var levelSectioninDb = await _unitofWork.LevelSectionRepository.SingleOrDefault(p => p.Id == id);

            if(levelSectioninDb == null)
                return NotFound();

            Transform(levelSectionDTO, levelSectioninDb);

            await _unitofWork.Commit();

            var result = Mapper.Map<LevelSection, LevelSectionDTO>(levelSectioninDb);
            return Ok(result);                  
        }

        private LevelSection Transform(LevelSection source, LevelSection destination)
        {
            destination.SectionId = source.SectionId;
            destination.LevelId = source.LevelId;
            destination.StationId = source.StationId;
            destination.SchoolYear = source.SchoolYear;
            destination.SectionAdviser.AdviserId = source.SectionAdviser.AdviserId;   

            return destination;        
        }

    }
}