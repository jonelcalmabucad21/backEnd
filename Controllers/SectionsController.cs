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
    public class SectionsController : Controller
    {
        
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;
        

        public SectionsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int count = await _unitofWork.SectionRepository.GetCount();

            var sections = await _unitofWork.SectionRepository.GetAll();
            
            var response = new {
                count,
                sections = Mapper.Map<IEnumerable<Section>, IEnumerable<SectionDTO>>(sections)
            };
            return Ok(response);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            int count = await _unitofWork.SectionRepository.GetCount();
            
            var sections = await _unitofWork.SectionRepository.GetAll(pageIndex,pageSize);
            
            var response = new {
                count,
                sections = Mapper.Map<IEnumerable<Section>, IEnumerable<SectionDTO>>(sections)
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SectionDTO sectionDTO)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = Mapper.Map<SectionDTO, Section>(sectionDTO);

            await _unitofWork.SectionRepository.AddAsync(section);
            await _unitofWork.Commit();

            section = await _unitofWork.SectionRepository.SingleOrDefault(p => p.Id == section.Id);
            
            return Ok(Mapper.Map<Section, SectionDTO>(section));       
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]SectionDTO sectionDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);    
        
            var sectioninDb = await _unitofWork.SectionRepository.SingleOrDefault(p => p.Id == id);

            if(sectioninDb == null)
                return NotFound();

            Mapper.Map<SectionDTO, Section>(sectionDTO,  sectioninDb);
            
            await _unitofWork.Commit();

            var result = Mapper.Map<Section, SectionDTO>( sectioninDb);
            return Ok(result);                  
        }
       
    }
    
}