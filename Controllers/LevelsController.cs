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

    public class LevelsController : Controller
    {
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;

        public LevelsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;            
        }
         
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var count = await _unitofWork.LevelRepository.GetCount();
            var levels = await _unitofWork.LevelRepository.GetAll();

            var response = new { 
                count,
                levels = Mapper.Map<IEnumerable<Level>, IEnumerable<LevelDTO>>(levels)
            };
            
            return Ok(response);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var count = await _unitofWork.LevelRepository.GetCount();
            var levels = await _unitofWork.LevelRepository.GetAll(pageIndex, pageSize);

            var response = new { 
                count,
                levels = Mapper.Map<IEnumerable<Level>, IEnumerable<LevelDTO>>(levels)
            };
            
            return Ok(response);
        }
    }
}