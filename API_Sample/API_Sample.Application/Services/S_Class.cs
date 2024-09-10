using API_Sample.Data.Model;
using API_Sample.Models.Common;
using API_Sample.Models.Request;
using API_Sample.Models.Response;
using API_Sample.Utilities.Constants;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Sample.Application.Services
{
    public interface IS_Class
    {
        Task<ResponseData<MRes_Class>> Create(MReq_Class request);
        Task<ResponseData<MRes_Class>> Update(MReq_Class request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_Class>> GetById(int id);
        Task<ResponseData<List<MRes_Class>>> getAll();
    }

    public class S_Class : IS_Class
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_Class(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseData<MRes_Class>> Create(MReq_Class request)
        {
            var res = new ResponseData<MRes_Class>();
            request.Code = request.Code.ToUpper().Trim();
            var isExistsCode = await _context.Classes.FirstOrDefaultAsync(x => x.Code == request.Code) != null;
            if (isExistsCode)
            {
                res.error.message = "Mã trùng lặp!";
                return res;
            }
            try
            {
                var data = new Class();
                data.Name = request.Name;
                data.Code = request.Code;
                data.ClassSize = request.ClassSize;
                data.Credits = request.Credits;
                data.GradeId = request.GradeId;
                data.Credits = request.Credits;
                data.SubjectId = request.SubjectId;
                _context.Classes.Add(data);
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
                var data = await _context.Classes.FindAsync(id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                _context.Classes.Remove(data);
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

        public async Task<ResponseData<List<MRes_Class>>> getAll()
        {
            var res = new ResponseData<List<MRes_Class>>();
            try
            {
                var data = await _context.Classes.ToListAsync();
                var mapData = _mapper.Map<List<MRes_Class>>(data);
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

        public async Task<ResponseData<MRes_Class>> GetById(int id)
        {
            var res = new ResponseData<MRes_Class>();
            try
            {
                var data = await _context.Classes.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_Class>(data);
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

        public async Task<ResponseData<MRes_Class>> Update(MReq_Class request)
        {
            var res = new ResponseData<MRes_Class>();
            try
            {
                var data = await _context.Classes.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                data.Name = request.Name;
                data.Code = request.Code;
                data.ClassSize = request.ClassSize;
                data.Credits = request.Credits;
                data.GradeId = request.GradeId;
                data.SubjectId = request.SubjectId;
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
