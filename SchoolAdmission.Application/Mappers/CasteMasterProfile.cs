using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class CasteMasterProfile : Profile
{
    public CasteMasterProfile()
    {
        CreateMap<CasteMasterDto, CasteMaster>()
        .ForMember(dest => dest.CasteId, opt => opt.Ignore());;
    }
}