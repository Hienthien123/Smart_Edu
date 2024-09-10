using API_Sample.Data.Entities;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.Models.Response;
using API_Sample.Utilities.Constants;
using API_Sample.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Sample.Data.EF;
using AutoMapper;
using API_Sample.Data.Model;

namespace API_Sample.Application.Services
{
    public interface IS_Subject
    {
        Task<ResponseData<MRes_Subject>> Create(MReq_Subject request);
        Task<ResponseData<MRes_Subject>> Update(MReq_Subject request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_Subject>> GetById(int id);
        Task<ResponseData<List<MRes_Subject>>> getAll();
    }

    public class S_Subject : IS_Subject
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_Subject(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseData<MRes_Subject>> Create(MReq_Subject request)
        {
            var res = new ResponseData<MRes_Subject>();
            request.SubjectName = request.SubjectName.ToUpper().Trim();
            var isExistsCode = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectName == request.SubjectName) != null;
            if (isExistsCode)
            {
                res.error.message = "Mã trùng lặp!";
                return res;
            }

            try
            {
                var data = new Subject();
                data.SubjectName = request.SubjectName;
                data.SubjectCode = request.SubjectCode;
                _context.Subjects.Add(data);
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

        public async Task<ResponseData<List<MRes_Subject>>> getAll()
        {
            var res = new ResponseData<List<MRes_Subject>>();
            try
            {
                var data = await _context.Subjects.ToListAsync();
                var mapData = _mapper.Map<List<MRes_Subject>>(data);
                res.data = mapData;
            }
            catch (Exception ex)
            {
                res.result = -1;
                res.error.code = 500;
                res.error.message = $"Exception: {ex.Message}\r\n{ex.InnerException?.Message}";
            }
            return res;
        }

        public async Task<ResponseData<MRes_Subject>> GetById(int id)
        {
            var res = new ResponseData<MRes_Subject>();
            try
            {
                var data = await _context.Subjects.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_Subject>(data);
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

        public async Task<ResponseData<MRes_Subject>> Update(MReq_Subject request)
        {
            var res = new ResponseData<MRes_Subject>();
            try
            {
                var data = await _context.Subjects.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                data.SubjectName = request.SubjectName;
                data.SubjectCode = request.SubjectCode;
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
