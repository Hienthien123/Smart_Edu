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
    public class StudentMapsTuitionController : ControllerBase
    {
        private readonly IS_StudentMapsTuition _s_StudentMapsTuition;

        public StudentMapsTuitionController(IS_StudentMapsTuition StudentMapsTuition)
        {
            _s_StudentMapsTuition = StudentMapsTuition;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MReq_StudentMapsTuition request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_StudentMapsTuition>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_StudentMapsTuition.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_StudentMapsTuition>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_StudentMapsTuition.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_StudentMapsTuition request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_StudentMapsTuition>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_StudentMapsTuition.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_StudentMapsTuition.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_StudentMapsTuition.GetById(id);
            return Ok(res);
        }
    }
}
