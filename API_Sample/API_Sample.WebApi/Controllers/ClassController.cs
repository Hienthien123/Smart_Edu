using API_Sample.Application.Services;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.WebApi.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Sample.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IS_Class _s_Class;

        public ClassController(IS_Class Class)
        {
            _s_Class = Class;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MReq_Class request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Class>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Class.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Class>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Class.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_Class request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Class>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Class.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_Class.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_Class.GetById(id);
            return Ok(res);
        }
    }
}
