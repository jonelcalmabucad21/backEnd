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
    public class RolesController : Controller
    {
        
        private IMapper _mapper { get; }
        private IUnitofWork _unitofWork;
        

        public RolesController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitofWork = unitofWork;

        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _unitofWork.RoleRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles));
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var roles = await _unitofWork.RoleRepository.GetAll(pageIndex,pageSize);
            return Ok(Mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles));
        }
    }
}