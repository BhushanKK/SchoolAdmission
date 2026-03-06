using AutoMapper;
using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Mappings;

public class CategoryMasterProfile : Profile
{
    public CategoryMasterProfile()
    {
        CreateMap<CategoryMasterDto, CategoryMaster>()
        .ForMember(dest => dest.categoryId, opt => opt.Ignore());;
    }
}