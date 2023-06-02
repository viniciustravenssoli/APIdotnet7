using AutoMapper;
using FirstAPIdotnet7.Domain.DTOs;
using FirstAPIdotnet7.Domain.Model;

namespace FirstAPIdotnet7.Application.Mapper
{
    public class DomainToDTOs : Profile 
    {
        public DomainToDTOs() 
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        }
    }
}
