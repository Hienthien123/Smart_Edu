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
    public class AttendanceController : ControllerBase
    {
        private readonly IS_Attendance _s_Attendance;

        public AttendanceController(IS_Attendance Attendance)
        {
            _s_Attendance = Attendance;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MReq_Attendance request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MRes_Product>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Attendance.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MRes_Product>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Attendance.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_Attendance request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Subject>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Attendance.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_Attendance.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_Attendance.GetById(id);
            return Ok(res);
        }
    }
}
