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
    public class TuitionController : ControllerBase
    {
        private readonly IS_Tuition _s_Tuition;

        public TuitionController(IS_Tuition Tuition)
        {
            _s_Tuition = Tuition;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MReq_Tuition request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Tuition>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Tuition.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Tuition>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Tuition.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_Tuition request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Tuition>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Tuition.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_Tuition.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_Tuition.GetById(id);
            return Ok(res);
        }
    }
}
