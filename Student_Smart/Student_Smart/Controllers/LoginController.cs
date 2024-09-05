using Core.Domains;
using Database.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;

namespace Student_Smart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;
     
        private readonly ILoginService _loginService;
        private readonly ILogger<EmployeeController> _logger;

        public LoginController(ILoginService loginService, ILogger<EmployeeController> logger, IWebHostEnvironment webHostEnvironment)
        { 

            _loginService = loginService;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {

            try
            {
                var result = await _loginService.Login(request);
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }

        }
       
    }
}
