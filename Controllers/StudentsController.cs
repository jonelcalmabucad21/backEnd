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
    public class StudentsController : Controller
    {
        private IUnitofWork _unitofWork { get; }
        private IMapper _mapper { get; }
        public StudentsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this._unitofWork = unitofWork;
            this._mapper = mapper;
        }      

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int count = await _unitofWork.StudentRepository.GetCount();
            var students = await _unitofWork.StudentRepository.GetAll();
            var response = new {
                count,
                students = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students)
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _unitofWork.StudentRepository.SingleOrDefault(p => p.Id == id);

            if(student == null)
                return NotFound();
            
            return Ok(Mapper.Map<Student, StudentDTO>(student));
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Get(int pageSize,int pageIndex, int schoolId)
        {
            int count  = await _unitofWork.StudentRepository.GetCount();
            var students = await _unitofWork.StudentRepository.GetAll(pageIndex, pageSize);

            var response = new {
                count,
                students = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students)
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StudentDTO studentDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = Mapper.Map<StudentDTO, Student>(studentDTO);

            await _unitofWork.StudentRepository.AddAsync(student);
            await _unitofWork.Commit();

            student = await _unitofWork.StudentRepository.SingleOrDefault(p => p.Id == student.Id);
            
            return Ok(Mapper.Map<Student, StudentDTO>(student));
        }

    }
}