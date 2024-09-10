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

namespace API_Sample.Application.Services
{
    public interface IS_StudentMapsClass
    {
        Task<ResponseData<MRes_StudentMapsClass>> Create(MReq_StudentMapsClass request);
        Task<ResponseData<MRes_StudentMapsClass>> Update(MReq_StudentMapsClass request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_StudentMapsClass>> GetById(int id);
        Task<ResponseData<List<MRes_StudentMapsClass>>> getAll();
    }
    public class S_StudentMapsClass : IS_StudentMapsClass
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_StudentMapsClass(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseData<MRes_StudentMapsClass>> Create(MReq_StudentMapsClass request)
        {
            var res = new ResponseData<MRes_StudentMapsClass>();
            try
            {
                var data = new StudentMapsClass();
                data.StudentId = request.StudentId;
                data.ClassId = request.ClassId;
                data.BehaviorScore = request.BehaviorScore;
                data.AverageTestScore = request.AverageTestScore;
                _context.StudentMapsClasses.Add(data);
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
                var data = await _context.StudentMapsClasses.FindAsync(id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                _context.StudentMapsClasses.Remove(data);
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

        public async Task<ResponseData<List<MRes_StudentMapsClass>>> getAll()
        {
            var res = new ResponseData<List<MRes_StudentMapsClass>>();
            try
            {
                var data = await _context.StudentMapsClasses.ToListAsync();
                var mapData = _mapper.Map<List<MRes_StudentMapsClass>>(data);
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

        public async Task<ResponseData<MRes_StudentMapsClass>> GetById(int id)
        {
            var res = new ResponseData<MRes_StudentMapsClass>();
            try
            {
                var data = await _context.StudentMapsClasses.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_StudentMapsClass>(data);
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

        public async Task<ResponseData<MRes_StudentMapsClass>> Update(MReq_StudentMapsClass request)
        {
            var res = new ResponseData<MRes_StudentMapsClass>();
            try
            {
                var data = await _context.StudentMapsClasses.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                data.ClassId = request.ClassId;
                data.StudentId = request.StudentId;
                data.BehaviorScore = request.BehaviorScore;
                data.AverageTestScore = request.AverageTestScore;
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
