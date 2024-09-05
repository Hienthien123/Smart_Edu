
using AutoMapper;
using Database.Model;
using LamLaiBaiCuoiKhoa.Helpers;
using Services.DTOs;

namespace Services.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, LoginDTO>().ReverseMap();
            CreateMap<Employee, Pagination>().ReverseMap();
        }
    }
}
