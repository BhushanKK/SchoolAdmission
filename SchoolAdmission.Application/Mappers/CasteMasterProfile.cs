using AutoMapper;
using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Mappings;

public class CasteMasterProfile : Profile
{
    public CasteMasterProfile()
    {
        CreateMap<CasteMasterDto, CasteMaster>()
        .ForMember(dest => dest.CasteId, opt => opt.Ignore());;
    }
}