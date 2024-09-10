using API_Sample.Data.Model;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.Models.Response;
using API_Sample.Utilities.Constants;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_Sample.Application.Services
{
    public interface IS_Grade
    {
        Task<ResponseData<MRes_Grade>> Create(MReq_Grade request);
        Task<ResponseData<MRes_Grade>> Update(MReq_Grade request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_Grade>> GetById(int id);
        Task<ResponseData<List<MRes_Grade>>> getAll();
    }

    public class S_Grade : IS_Grade
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_Grade(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseData<MRes_Grade>> Create(MReq_Grade request)
        {
            var res = new ResponseData<MRes_Grade>();
            request.Code = request.Code.ToUpper().Trim();
            var isExistsCode = await _context.Grades.FirstOrDefaultAsync(x => x.Code == request.Code) != null;
            if (isExistsCode)
            {
                res.error.message = "Mã trùng lặp!";
                return res;
            }


            try
            {
                var data = new Grade();
                data.Name = request.Name;
                data.Code = request.Code;
                data.IsSeniorGrade = request.IsSeniorGrade;
                _context.Grades.Add(data);
                var save = await _context.SaveChangesAsync();
                if (save == 0)
                {
                    res.error.code = 400;
                    res.error.message = MessageErrorConstants.EXCEPTION_DO_NOT_CREATE;
                    return res;
                }
                res.result = 1;
                res.error.code = 201;
                res.error.message = MessageErrorConstants.CREATE_SUCCESS;
            }
            catch (Exception ex)
            {
                res.result = -1;
                res.error.code = 500;
                res.error.message = $"Exception: {ex.Message}\r\n{ex.InnerException?.Message}";
            }
            return res;
        }

        public async Task<ResponseData<int>> Delete(int id)
        {
            var res = new ResponseData<int>();
            try
            {
                var data = await _context.Subjects.FindAsync(id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                _context.Subjects.Remove(data);
                var save = await _context.SaveChangesAsync();
                if (save == 0)
                {
                    res.error.code = 400;
                    res.error.message = MessageErrorConstants.EXCEPTION_DO_NOT_DELETE;
                    return res;
                }
                res.data = save;
                res.result = 1;
                res.error.message = MessageErrorConstants.DELETE_SUCCESS;
            }
            catch (Exception ex)
            {
                res.result = -1;
                res.error.code = 500;
                res.error.message = $"Exception: {ex.Message}\r\n{ex.InnerException?.Message}";
            }
            return res;
        }

        public async Task<ResponseData<List<MRes_Grade>>> getAll()
        {
            var res = new ResponseData<List<MRes_Grade>>();
            try
            {
                var data = await _context.Grades.ToListAsync();
                var mapData = _mapper.Map<List<MRes_Grade>>(data);
                res.data = mapData;
            }
            catch(Exception ex)
            {
                res.result = -1;
                res.error.code = 500;
                res.error.message = $"Exception: {ex.Message}\r\n{ex.InnerException?.Message}";
            }
            return res;
        }

        public async Task<ResponseData<MRes_Grade>> GetById(int id)
        {
            var res = new ResponseData<MRes_Grade>();
            try
            {
                var data = await _context.Grades.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_Grade>(data);
                res.data = mapData;
                res.result = 1;
            }
            catch (Exception ex)
            {
                res.result = -1;
                res.error.code = 500;
                res.error.message = $"Exception: {ex.Message}\r\n{ex.InnerException?.Message}";
            }
            return res;
        }

        public async Task<ResponseData<MRes_Grade>> Update(MReq_Grade request)
        {
            var res = new ResponseData<MRes_Grade>();
            try
            {
                var data = await _context.Grades.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                data.Name = request.Name;
                data.Code = request.Code;
                _context.Update(data);
                var save = await _context.SaveChangesAsync();
                if (save == 0)
                {
                    res.error.code = 400;
                    res.error.message = MessageErrorConstants.EXCEPTION_DO_NOT_UPDATE;
                    return res;
                }
                res.result = 1;
                res.error.message = MessageErrorConstants.UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                res.result = -1;
                res.error.code = 500;
                res.error.message = $"Exception: {ex.Message}\r\n{ex.InnerException?.Message}";
            }
            return res;
        }
    }
}
