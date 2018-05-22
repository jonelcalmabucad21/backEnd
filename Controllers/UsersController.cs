using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using backEnd.Controllers.DataTransferObjects;
using backEnd.Models;
using backEnd.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IConfiguration config;

        private IUnitofWork _unitofWork { get; }
        private IMapper _mapper { get; }
        public UsersController(IUnitofWork unitofWork, IMapper mapper, IConfiguration config)
        {
            this.config = config;
            this._unitofWork = unitofWork;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int count = await _unitofWork.UserRepository.GetCount();
            var users = await _unitofWork.UserRepository.GetAll();
            var response = new
            {
                count,
                users = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users)
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserDTO userSaveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = Mapper.Map<UserDTO, User>(userSaveResource);
            var roleAccess = await _unitofWork.RoleAccessRepository.GetAll(p => p.RoleId == user.UserRole.RoleId);
            
            var claims = new List<string>();
            foreach(var access in roleAccess)
            {
                user.UserAccesses.Add(new UserAccess{
                    AccessId = access.AccessId
                });
            }

            await _unitofWork.UserRepository.AddAsync(user);
            await _unitofWork.Commit();

            user = await _unitofWork.UserRepository.SingleOrDefault(p => p.Id == user.Id);

            var result = Mapper.Map<User, UserDTO>(user);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login user)
        {

            var userinDb = await _unitofWork.UserRepository.SingleOrDefault(p => p.EmployeeNumber == user.EmployeeNumber && p.Password == user.Password);
            
            if (userinDb != null)
            {
                var userDTO = Mapper.Map<User, UserDTO>(userinDb); 

                StationId.Id = userDTO.Employee.Station.Id; // determine the station of user

                var claims = new List<Claim>();
                var claimsHeader = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userDTO.EmployeeNumber),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, userDTO.Employee.Person.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, userDTO.Employee.Person.LastName),
                    new Claim("Role", userDTO.UserRole.Role.Name),
                    new Claim("SchoolId", userDTO.Employee.Station.SchoolId.ToString()),
                    new Claim("StationId", userDTO.Employee.Station.Id.ToString()),
                    new Claim("Station", userDTO.Employee.Station.Name),
                    new Claim("EmployeeId", userDTO.EmployeeId.ToString()),
                    new Claim("EmployeeNumber", userDTO.Employee.EmployeeNumber),
                    new Claim("Position", userDTO.Employee.Position.Name)
                };   
                
                claims.AddRange(claimsHeader);
                
                foreach (var claim in userinDb.UserAccesses)
                    claims.Add(new Claim(claim.Access.Name,"True"));
                

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Tokens:Key").ToString()));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: config["Tokens:Issuer"],
                    audience: config["Tokens:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }

    }

    public class StationId 
    {
        public static int Id { get; set; }

    }

}