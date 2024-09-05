using AutoMapper;
using Database;
using Database.Model;
using LamLaiBaiCuoiKhoa.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repositories;
using Services.DTOs;
namespace Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAll();
        Task<PageResult<EmployeeDTO>> PaginationEmployee(Pagination pagination);
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<EmployeeDTO> CreateEmployee(EmployeeDTO payload);
        Task<EmployeeDTO> UpdateEmployee(EmployeeDTO payload);
        Task<int> DeleteEmployee(int id);
        Task<IEnumerable<Employee>> SearchFilterEmployee(string filter);
        
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        // private readonly ILocationSpecificService _locationSpecificService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;
        private readonly WebApiContext _webApiContext;
        private readonly IConfiguration _configuration;
        public EmployeeService(IEmployeeRepository employeeRepository,
            IMapper mapper, ILogger<EmployeeService> logger, WebApiContext webApiContext, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _webApiContext = webApiContext;
            _configuration = configuration;
        }
        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO payload)
        {
            var data = _mapper.Map<Employee>(payload);
            try
            {
                data.LastName = BCrypt.Net.BCrypt.HashPassword(payload.LastName);
                await _employeeRepository.AddAsync(data);
                await _employeeRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _mapper.Map<EmployeeDTO>(data);

        }
        public async Task<int> DeleteEmployee(int id)
        {
            var foundItem = _employeeRepository.FirstOrDefault(x => x.Id == id);
            if (foundItem == null)
            {
                throw new Exception("Item not found");
            }
            try
            {
                _employeeRepository.Remove(foundItem);
                await _employeeRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var data = _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(data);

        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var data = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("Item not found");
            }
            return _mapper.Map<EmployeeDTO>(data);
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO payload)
        {
            var data = _employeeRepository.FirstOrDefault(c => c.Id == payload.Id);
            if (data == null)
            {
                throw new Exception($"{payload.Id} was not found");
            }
            data.FullName = payload.FullName;
            data.LastName = payload.LastName;
            data.Gender = payload.Gender;
            data.Email = payload.Email;
            data.PhoneNumber = payload.PhoneNumber;
            data.Ethnicity = payload.Ethnicity;
            data.Religion = payload.Religion;
            data.IdentificationNumber = payload.IdentificationNumber;
            data.Nationality = payload.Nationality;
            data.TaxIdentificationNumber = payload.TaxIdentificationNumber;
            data.EmergencyContactName = payload.EmergencyContactName;
            data.EmergencyContactYearOfBirth = payload.EmergencyContactYearOfBirth;
            await _employeeRepository.SaveChanges();
            return _mapper.Map<EmployeeDTO>(data);
        }
       

        public async Task<PageResult<EmployeeDTO>> PaginationEmployee(Pagination pagination)
        {
            var data = _employeeRepository.GetAll();
            var mappedData = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
            var pagedResult = PageResult<EmployeeDTO>.ToPagedResult(pagination, mappedData);

            return pagedResult;
        }

        public async Task<IEnumerable<Employee>> SearchFilterEmployee(string filter)
        {
            var data = _webApiContext.EmployeeModels
                        .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()));

            if (!data.Any())
            {
                throw new Exception("Hiện không có bản ghi nào.");
            }

            return data;
        }
        

   
    }
}
