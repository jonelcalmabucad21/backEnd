using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backEnd.Controllers.Resources;
using backEnd.Models;
using backEnd.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    public class PrincipalsController : Controller
    {
        private IUnitofWork _unitofWork { get; }
        private IMapper _mapper { get; }
        public PrincipalsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitofWork = unitofWork;
            this._mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var principals = await _unitofWork.PrincipalRepository.GetAll();
            var count = await _unitofWork.PrincipalRepository.GetCount();
            var response = new {
                count,
                principals = Mapper.Map<IEnumerable<Principal>,IEnumerable<PrincipalResource>>(principals)
            };
            return Ok(response);
        }
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageSize,int pageIndex)
        {
            var principals = await _unitofWork.PrincipalRepository.GetAll(pageIndex,pageSize);
            var count = await _unitofWork.PrincipalRepository.GetCount();
            var response = new {
                count,
                principals = Mapper.Map<IEnumerable<Principal>,IEnumerable<PrincipalResource>>(principals)
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var principal = await _unitofWork.EmployeeRepository.SingleOrDefault(p => p.Principals.Count !=0 && p.Id == id);

            return Ok(Mapper.Map<Employee,EmployeeResource>(principal));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PrincipalSaveResource principalSaveResource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var principal = Mapper.Map<PrincipalSaveResource, Principal>(principalSaveResource);

            var existingPrincipal = await _unitofWork.PrincipalRepository
                .SingleOrDefault(p => p.SchoolYear == principalSaveResource.SchoolYear && p.StationId == principalSaveResource.StationId && p.EndDate == null);

            if(existingPrincipal != null)
            {
                return BadRequest("There is an Existing Principal");
            }

            await _unitofWork.PrincipalRepository.AddAsync(principal);
            await _unitofWork.Commit();

            principal = await _unitofWork.PrincipalRepository.SingleOrDefault(p => p.Id == principal.Id);

            var result = Mapper.Map<Principal, PrincipalSaveResource>(principal);

            return Ok(result);
        }

    }
}