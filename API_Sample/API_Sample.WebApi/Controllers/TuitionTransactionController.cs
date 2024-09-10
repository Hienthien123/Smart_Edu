﻿
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
    public class TuitionTransactionController : ControllerBase
    {
        private readonly IS_TuitionTransaction _s_TuitionTransaction;

        public TuitionTransactionController(IS_TuitionTransaction TuitionTransaction)
        {
            _s_TuitionTransaction = TuitionTransaction;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MReq_TuitionTransaction request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_TuitionTransaction>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_TuitionTransaction.Create(request);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_TuitionTransaction>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_TuitionTransaction.getAll();
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update(MReq_TuitionTransaction request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseData<MReq_TuitionTransaction>(0, 400, DataAnnotationExtensionMethod.GetErrorMessage(ModelState)));
            var res = await _s_TuitionTransaction.Update(request);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHard(int id)
        {
            var res = await _s_TuitionTransaction.Delete(id);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _s_TuitionTransaction.GetById(id);
            return Ok(res);
        }
    }
}
