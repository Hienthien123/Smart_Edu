using API_Sample.Application.Services;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.Models.Response;
using API_Sample.WebApi.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Sample.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeMapsClassController : ControllerBase
    {
        private readonly IS_EmployeeMapsClass _s_EmployeeMapsClass;

        public EmployeeMapsClassController(IS_EmployeeMapsClass EmployeeMapsClass)
        {
            _s_EmployeeMapsClass = EmployeeMapsClass;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MReq_EmployeeMapsClass request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_EmployeeMapsClass>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_EmployeeMapsClass.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_EmployeeMapsClass>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_EmployeeMapsClass.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_EmployeeMapsClass request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_EmployeeMapsClass>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_EmployeeMapsClass.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_EmployeeMapsClass.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_EmployeeMapsClass.GetById(id);
            return Ok(res);
        }
    }
}
