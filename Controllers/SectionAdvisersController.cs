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

    public class SectionAdvisersController : Controller
    {
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;

        public SectionAdvisersController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;
        }     

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sectionAdvisers = await _unitofWork.SectionAdviserRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<SectionAdviser>, IEnumerable<SectionAdviser01DTO>>(sectionAdvisers));
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var SectionAdvisers = await _unitofWork.SectionAdviserRepository.GetAll(pageIndex,pageSize);
            return Ok(Mapper.Map<IEnumerable<SectionAdviser>, IEnumerable<SectionAdviser01DTO>>(SectionAdvisers));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SectionAdviser01DTO sectionAdviser01DTO)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var sectionAdviser = Mapper.Map<SectionAdviser01DTO, SectionAdviser>(sectionAdviser01DTO);

            await _unitofWork.SectionAdviserRepository.AddAsync(sectionAdviser);
            await _unitofWork.Commit();

            sectionAdviser = await _unitofWork.SectionAdviserRepository.SingleOrDefault(p => p.Id == sectionAdviser.Id);
            
            return Ok(Mapper.Map<SectionAdviser, SectionAdviser01DTO>(sectionAdviser));       
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]SectionAdviser01DTO sectionAdviser01DTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);    

            var sectionAdviserinDb = await _unitofWork.SectionAdviserRepository.SingleOrDefault(p => p.Id == id);

            if(sectionAdviserinDb == null)
                return NotFound();

            Mapper.Map<SectionAdviser01DTO, SectionAdviser>(sectionAdviser01DTO, sectionAdviserinDb);
            
            await _unitofWork.Commit();

            var result = Mapper.Map<SectionAdviser, SectionAdviser01DTO>(sectionAdviserinDb);
            return Ok(result);                  
        }
       
    }
}