using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class CategoryMasterProfile : Profile
{
    public CategoryMasterProfile()
    {
        CreateMap<CategoryMasterCommandDto, CategoryMaster>()
        .ForMember(dest => dest.categoryId, opt => opt.Ignore());
    }
}