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
    public interface IS_Attendance
    {
        Task<ResponseData<MRes_Attendance>> Create(MReq_Attendance request);
        Task<ResponseData<MRes_Attendance>> Update(MReq_Attendance request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_Attendance>> GetById(int id);
        Task<ResponseData<List<MRes_Attendance>>> getAll();
    }
    public class S_Attendance : IS_Attendance
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_Attendance(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseData<MRes_Attendance>> Create(MReq_Attendance request)
        {
            var res = new ResponseData<MRes_Attendance>();
            try
            {
                var data = new Attendance();
                data.StudentId = request.StudentId;
                data.ClassId = request.ClassId;
                data.ClassDate = request.ClassDate;
                data.Status = request.Status;
                data.Note = request.Note;
                _context.Attendances.Add(data);
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
            return res; ;
        }

        public async Task<ResponseData<int>> Delete(int id)
        {
            var res = new ResponseData<int>();
            try
            {
                var data = await _context.Attendances.FindAsync(id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                _context.Attendances.Remove(data);
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

        public async Task<ResponseData<List<MRes_Attendance>>> getAll()
        {
            var res = new ResponseData<List<MRes_Attendance>>();
            try
            {
                var data = await _context.Attendances.ToListAsync();
                var mapData = _mapper.Map<List<MRes_Attendance>>(data);
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

        public async Task<ResponseData<MRes_Attendance>> GetById(int id)
        {
            var res = new ResponseData<MRes_Attendance>();
            try
            {
                var data = await _context.Attendances.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_Attendance>(data);
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

        public async Task<ResponseData<MRes_Attendance>> Update(MReq_Attendance request)
        {
            var res = new ResponseData<MRes_Attendance>();
            try
            {
                var data = await _context.Attendances.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                data.StudentId = request.StudentId;
                data.ClassId = request.ClassId;
                data.ClassDate = request.ClassDate;
                data.Status = request.Status;
                data.Note = request.Note;
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
