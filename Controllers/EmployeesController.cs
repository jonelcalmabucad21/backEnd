using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using backEnd.Controllers.DataTransferObjects;
using backEnd.Controllers.Resources;
using backEnd.Models;
using backEnd.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Controllers
{
    [Route("api/[controller]") ]

    public class EmployeesController : Controller
    {
        private IUnitofWork _unitofWork { get; }
        private IMapper _mapper { get;  }
        public EmployeesController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitofWork = unitofWork;
            this._mapper = mapper;
        }
        // GET api/employees/ForRegistration
        [HttpGet("ForRegistration")]
        public async Task<IActionResult> GetEmployeeNumber()
        {
            var employees = await _unitofWork.EmployeeRepository.GetEmployeeForRegistration();
             

            return Ok(Mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDTO>>(employees));
        }
        // GET api/employees
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int count =  await _unitofWork.EmployeeRepository.GetCount();
            var employees = await _unitofWork.EmployeeRepository.GetAll();
            var response = new {
                count,
                employees = Mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDTO>>(employees)
            };
            return Ok(response);
        }
        // GET api/employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _unitofWork.EmployeeRepository.SingleOrDefault(p => p.Id == id);

            if(employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee,EmployeeDTO>(employee));   
        }
        // GET api/employees/1/10
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageSize,int pageIndex, int schoolId)
        {
 
            var employees = await _unitofWork.EmployeeRepository.GetAll(pageIndex,pageSize);
            int count = _unitofWork.EmployeeRepository.EmployeeIds.Count();
                        
            var response = new {
                count,
                employees = Mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDTO>>(employees)
            };
             
            return Ok(response);
        }
        
        // GET api/employees/?employeeNumber=123123
        [HttpGet("getByemployeeNumber/{employeeNumber}")]
         public async Task<IActionResult> GetbyEmployeeNumber(string employeeNumber)
        {
           var employee = await _unitofWork.EmployeeRepository.SingleOrDefault(p => p.EmployeeNumber == employeeNumber);

           if(employee == null)
                return NotFound();

           var result = Mapper.Map<Employee, EmployeeDTO>(employee);

           return Ok(result);      
        }  
        // POST api/employees
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EmployeeDTO employeeDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            
            var employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            
            await _unitofWork.EmployeeRepository.AddAsync(employee);
            await _unitofWork.Commit();

            employee = await _unitofWork.EmployeeRepository.SingleOrDefault(p => p.Id == employee.Id);    
                      
            return Ok(Mapper.Map<Employee, EmployeeDTO>(employee));
        }
        // PUT api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]EmployeeDTO employeeDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);    

            var employee = await _unitofWork.EmployeeRepository.SingleOrDefault(p => p.Id == id);
            var person = new Person();

            if(employee == null)
                return NotFound();
            
            person = await _unitofWork.PersonRepository.SingleOrDefault(p => p.Id == employee.PersonId);
            
            if(employee.PersonId != employeeDTO.PersonId)
            {
                
                await _unitofWork.PersonRepository.RemoveAsync(person);
            }

            Mapper.Map<EmployeeDTO, Employee>(employeeDTO, employee);
            
            await _unitofWork.Commit();

            var result = Mapper.Map<Employee, EmployeeDTO>(employee);
            return Ok(result);                  
        }
        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitofWork.EmployeeRepository.SingleOrDefault(p => p.Id == id);

            if(employee == null)
                return NotFound();     
            
            await _unitofWork.EmployeeStationRepository.RemoveRangeAsync(employee.EmployeeStations);
            await _unitofWork.EmployeePositionRepository.RemoveRangeAsync(employee.EmployeePositions);
            await _unitofWork.EmployeeRepository.RemoveAsync(employee);
            await _unitofWork.Commit();

            return Ok(id);      
        }      
    }
}