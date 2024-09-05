using Database.Model;
using Database;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Repositories;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface ILoginService
    {
        Task<string> Login(LoginDTO payload);

    }
    public class LoginService : ILoginService
    {
        private readonly IEmployeeRepository _employeeRepository;
        //private readonly ILocationSpecificService _locationSpecificService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;
        private readonly WebApiContext _webApiContext;
        private readonly IConfiguration _configuration;
        public LoginService(IEmployeeRepository employeeRepository,
            IMapper mapper, ILogger<EmployeeService> logger, WebApiContext webApiContext, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _webApiContext = webApiContext;
            _configuration = configuration;
        }
        public async Task<string> Login(LoginDTO payload)
        {

            var employee = await _webApiContext.EmployeeModels
                                    .FirstOrDefaultAsync(e => e.FirstName == payload.FirstName);
            if (employee == null)
            {
                throw new Exception("Item not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(payload.LastName, employee.LastName))
            {
                throw new Exception("Wrong password");
            }

            var token = CreateToken(employee);
            return token;
        }

        private string CreateToken(Employee employee)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            List<Claim> claims = new List<Claim>
            {

                new Claim("FirstName", employee.FirstName),
                new Claim("LastName", employee.LastName),
                new Claim("LoginTime", DateTime.UtcNow.ToString())
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                 issuer: issuer,
                 audience: audience,
                 claims: claims,
                 expires: DateTime.Now.AddDays(1),
                 signingCredentials: creds
             );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
