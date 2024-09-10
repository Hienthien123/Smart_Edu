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
    public interface IS_Employee
    {
        Task<ResponseData<MRes_Employee>> Create(MReq_Employee request);
        Task<ResponseData<MRes_Employee>> Update(MReq_Employee request);
        Task<ResponseData<int>> Delete(int id);
        Task<ResponseData<MRes_Employee>> GetById(int id);
        Task<ResponseData<List<MRes_Employee>>> getAll();
    }
    public class S_Employee : IS_Employee
    {
        private readonly DemoDataContext _context;
        private readonly IMapper _mapper;

        public S_Employee(DemoDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseData<MRes_Employee>> Create(MReq_Employee request)
        {
            var res = new ResponseData<MRes_Employee>();
            try
            {
                var data = new Employee();
                data.FullName = request.FullName;
                data.LastName = request.LastName;
                data.FirstName = request.FirstName;
                data.Code = request.Code;
                data.Gender = request.Gender;   
                data.Address = request.Address;
                data.DateOfBirth = request.DateOfBirth;
                data.Email = request.Email;   
                data.PhoneNumber = request.PhoneNumber;
                data.Ethnicity = request.Ethnicity;
                data.Religion = request.Religion;
                data.IdentificationNumber = request.IdentificationNumber;
                data.TaxIdentificationNumber = request.TaxIdentificationNumber;
                data.Nationality = request.Nationality;
                data.EmergencyContactName = request.EmergencyContactName;
                data.EmergencyContactJob = request.EmergencyContactJob;
                data.EmergencyContactNumber = request.EmergencyContactNumber;
                data.EmergencyContactYearOfBirth = request.EmergencyContactYearOfBirth;
                data.SubjectId = request.SubjectId;
                data.RoleId = request.RoleId;
                _context.Employees.Add(data);
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
                var data = await _context.Employees.FindAsync(id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }

                _context.Employees.Remove(data);
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

        public async Task<ResponseData<List<MRes_Employee>>> getAll()
        {
            var res = new ResponseData<List<MRes_Employee>>();
            try
            {
                var data = await _context.Employees.ToListAsync();
                var mapData = _mapper.Map<List<MRes_Employee>>(data);
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

        public async Task<ResponseData<MRes_Employee>> GetById(int id)
        {
            var res = new ResponseData<MRes_Employee>();
            try
            {
                var data = await _context.Employees.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                var mapData = _mapper.Map<MRes_Employee>(data);
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

        public async Task<ResponseData<MRes_Employee>> Update(MReq_Employee request)
        {
            var res = new ResponseData<MRes_Employee>();
            try
            {
                var data = await _context.Employees.FindAsync(request.Id);
                if (data == null)
                {
                    res.error.message = MessageErrorConstants.DO_NOT_FIND_DATA;
                    return res;
                }
                data.FullName = request.FullName;
                data.LastName = request.LastName;
                data.FirstName = request.FirstName;
                data.Gender = request.Gender;
                data.Code = data.Code;
                data.Address = request.Address;
                data.DateOfBirth = request.DateOfBirth;
                data.Email = request.Email;
                data.PhoneNumber = request.PhoneNumber;
                data.Ethnicity = request.Ethnicity;
                data.Religion = request.Religion;
                data.IdentificationNumber = request.IdentificationNumber;
                data.TaxIdentificationNumber = request.TaxIdentificationNumber;
                data.Nationality = request.Nationality;
                data.EmergencyContactName = request.EmergencyContactName;
                data.EmergencyContactJob = request.EmergencyContactJob;
                data.EmergencyContactNumber = request.EmergencyContactNumber;
                data.EmergencyContactYearOfBirth = request.EmergencyContactYearOfBirth;
                data.SubjectId = request.SubjectId;
                data.RoleId = request.RoleId;
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
