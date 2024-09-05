using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services;
using Core.Domains;
using LamLaiBaiCuoiKhoa.Helpers;
using Microsoft.AspNetCore.Authorization;
using Database.Model;

namespace Student_Smart.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {

            _employeeService = employeeService;
            _logger = logger;
        }
        //[HttpGet("GetFilteredEmployeeList")]
        //public async Task<IActionResult> GetFilteredEmployeeList(int? pageNumber, int? pageSize, int? organizationId, string name)
        //{
        //    try
        //    {
        //        var result = await _employeeService.GetFilteredEmployeeList(pageNumber, pageSize, organizationId, name);
        //        return Ok(new BaseResponseModel(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
        //    }
        //}

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("{Timestamp} [{Provider}] GetAll API is running", DateTime.Now, "TestController");
            
                var result = await _employeeService.GetAll();
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet("GetByIdEmployee/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _employeeService.GetEmployeeById(id);
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> Create(EmployeeDTO payload)
        {
            try
            {
                var firstName = User.Claims.FirstOrDefault(c => c.Type == "FirstName")?.Value;
                var loginTime = User.Claims.FirstOrDefault(c => c.Type == "LoginTime")?.Value;
                var result = await _employeeService.CreateEmployee(payload);
               
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> Update(EmployeeDTO payload)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(payload);
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }

        }
        [HttpPost("PaginationEmployee")]
        public async Task<IActionResult> PaginationEmployee(Pagination pagination)
        {
            try
            {
                var result = await _employeeService.PaginationEmployee(pagination);
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }

        }
        [HttpPost("SearchFilterEmployee")]
        public async Task<IActionResult> SearchFilterEmployee(string filter)
        {
            try
            {
                var result = await _employeeService.SearchFilterEmployee(filter);
                return Ok(new BaseResponseModel(result));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponseModel(null, false, StatusCodes.Status500InternalServerError, ex.Message));
            }

        }
     
    }
}
