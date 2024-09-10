using API_Sample.Application.Services;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.Models.Response;
using API_Sample.WebApi.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Sample.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
   
    public class SubjectController : ControllerBase
    {
            private readonly IS_Subject _s_Subject;

            public SubjectController(IS_Subject Subject)
            {
                _s_Subject = Subject;
            }

            [HttpPost]
            public async Task<IActionResult> Create(MReq_Subject request)
            {
                if (!ModelState.IsValid)
                    return Ok(new ResponseData<MRes_Product>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
                var res = await _s_Subject.Create(request);
                return Ok(res);
            }
            [HttpPost]
            public async Task<IActionResult> getAll()
            {
                if (!ModelState.IsValid)
                    return Ok(new ResponseData<MReq_Subject>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
                var res = await _s_Subject.getAll();
                return Ok(res);
            }
            [HttpPut]
            public async Task<IActionResult> Update(MReq_Subject request)
            {
                if (!ModelState.IsValid)
                    return Ok(new ResponseData<MReq_Subject>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
                var res = await _s_Subject.Update(request);
                return Ok(res);
            }
            [HttpDelete]
            public async Task<IActionResult> DeleteHard(int id)
            {
                var res = await _s_Subject.Delete(id);
                return Ok(res);
            }
            [HttpGet]
            public async Task<IActionResult> GetById(int id)
            {
                var res = await _s_Subject.GetById(id);
                return Ok(res);
            }
    }
}
