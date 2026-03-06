using AutoMapper;
<<<<<<< HEAD
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
=======
using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain;
>>>>>>> e03a7420fa60e677bdf43fde721deaaeb7a2939a

namespace SchoolAdmission.Application.Mappings;

public class CategoryMasterProfile : Profile
{
    public CategoryMasterProfile()
    {
<<<<<<< HEAD
        CreateMap<CategoryMasterCommandDto, CategoryMaster>()
=======
        CreateMap<CategoryMasterDto, CategoryMaster>()
>>>>>>> e03a7420fa60e677bdf43fde721deaaeb7a2939a
        .ForMember(dest => dest.categoryId, opt => opt.Ignore());;
    }
}