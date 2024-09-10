using API_Sample.Application.Services;
using API_Sample.Data.Model;
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
    public class StudentMapsClassController : ControllerBase
    {
        private readonly IS_StudentMapsClass _s_StudentMapsClass;

        public StudentMapsClassController(IS_StudentMapsClass StudentMapsClass)
        {
            _s_StudentMapsClass = StudentMapsClass;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MReq_StudentMapsClass request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_StudentMapsClass>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_StudentMapsClass.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_StudentMapsClass>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_StudentMapsClass.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_StudentMapsClass request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_StudentMapsClass>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_StudentMapsClass.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_StudentMapsClass.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_StudentMapsClass.GetById(id);
            return Ok(res);
        }
    }
}
