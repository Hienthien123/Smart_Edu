using AutoMapper;
using API_Sample.Data.Entities;
using API_Sample.Models.Common;
using API_Sample.Models.Response;
using API_Sample.Data.Model;
using API_Sample.Models.Request;

namespace API_Sample.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Common
            CreateMap<Image, MRes_Image>();
            CreateMap<Image, BaseModel.Image>();
           

            //Main
           // CreateMap<Product, MRes_Product>();
            CreateMap<Subject, MRes_Subject>();
            CreateMap<Grade, MRes_Grade>();
            CreateMap<Attendance, MRes_Attendance>();
            CreateMap<Employee, MRes_Employee>();
            CreateMap<EmployeeMapsClass, MRes_EmployeeMapsClass>();
            CreateMap<Role, MRes_Role>();
            CreateMap<Student, MRes_Student>();
            CreateMap<StudentMapsClass, MRes_StudentMapsClass>();
            CreateMap<StudentMapsTuition, MRes_StudentMapsTuition>();
            CreateMap<Tuition, MRes_Tuition>();
            CreateMap<TuitionTransaction, MRes_TuitionTransaction>();
            CreateMap<Class, MRes_Class>(); 

        }
    }
}
