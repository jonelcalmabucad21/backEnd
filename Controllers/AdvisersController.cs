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

    public class AdvisersController : Controller
    {

        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;

        public AdvisersController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;            
        }
         
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var count = await _unitofWork.AdviserRepository.GetCount();
            var advisers = await _unitofWork.AdviserRepository.GetAll();

            var response = new { 
                count,
                advisers = Mapper.Map<IEnumerable<Adviser>, IEnumerable<AdviserDTO>>(advisers)
            };
            
            return Ok(response);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var count = await _unitofWork.AdviserRepository.GetCount();
            var Advisers = await _unitofWork.AdviserRepository.GetAll(pageIndex, pageSize);

            var response = new { 
                count,
                Advisers = Mapper.Map<IEnumerable<Adviser>, IEnumerable<AdviserDTO>>(Advisers)
            };
            
            return Ok(response);
        }
    }
}