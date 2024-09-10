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
    public interface IS_StudentMapsTuition
    {
        Task<ResponseData<MRes_StudentMapsTuition>> Create(MReq_StudentMapsTuition request);
        Task<ResponseData<MRes_StudentMapsTuition>> Update(MReq_StudentMapsTuition request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_StudentMapsTuition>> GetById(int id);
        Task<ResponseData<List<MRes_StudentMapsTuition>>> getAll();
    }
    public class S_StudentMapsTuition : IS_StudentMapsTuition
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_StudentMapsTuition(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseData<MRes_StudentMapsTuition>> Create(MReq_StudentMapsTuition request)
        {
            var res = new ResponseData<MRes_StudentMapsTuition>();
            try
            {
                var data = new StudentMapsTuition();
                data.StudentId = request.StudentId;
                data.ClassId = request.ClassId;
                data.TuitionId = request.TuitionId;
                data.DiscountPercentage = request.DiscountPercentage;
                data.DiscountAmount = request.DiscountAmount;
                data.Note = request.Note;
                data.AppliedDate = request.AppliedDate;
                data.EndDate = request.EndDate;
                _context.StudentMapsTuitions.Add(data);
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
                var data = await _context.StudentMapsTuitions.FindAsync(id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                _context.StudentMapsTuitions.Remove(data);
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

        public async Task<ResponseData<List<MRes_StudentMapsTuition>>> getAll()
        {
            var res = new ResponseData<List<MRes_StudentMapsTuition>>();
            try
            {
                var data = await _context.StudentMapsTuitions.ToListAsync();
                var mapData = _mapper.Map<List<MRes_StudentMapsTuition>>(data);
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

        public async Task<ResponseData<MRes_StudentMapsTuition>> GetById(int id)
        {
            var res = new ResponseData<MRes_StudentMapsTuition>();
            try
            {
                var data = await _context.StudentMapsTuitions.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_StudentMapsTuition>(data);
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

        public async Task<ResponseData<MRes_StudentMapsTuition>> Update(MReq_StudentMapsTuition request)
        {
            var res = new ResponseData<MRes_StudentMapsTuition>();
            try
            {
                var data = await _context.StudentMapsTuitions.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                data.StudentId = request.StudentId;
                data.ClassId = request.ClassId;
                data.TuitionId = request.TuitionId;
                data.DiscountPercentage = request.DiscountPercentage;
                data.DiscountAmount = request.DiscountAmount;
                data.Note = request.Note;
                data.AppliedDate = request.AppliedDate;
                data.EndDate = request.EndDate;
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
