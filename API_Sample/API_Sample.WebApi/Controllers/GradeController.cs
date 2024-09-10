using API_Sample.Application.Services;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.Models.Response;
using API_Sample.WebApi.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Sample.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IS_Grade _s_Grade;

        public GradeController(IS_Grade Grade)
        {
            _s_Grade = Grade;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MReq_Grade request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Grade>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Grade.Create(request);
            return Ok(res);
        }
        [HttpPost]

        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Grade>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Grade.getAll();
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_Grade.Delete(id);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_Grade request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_Grade>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_Grade.Update(request);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_Grade.GetById(id);
            return Ok(res);
        }

    }
}
