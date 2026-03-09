using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class SchoolMasterProfile : Profile
{
    public SchoolMasterProfile()
    {
        CreateMap<SchoolMasterCommandDto, SchoolMaster>()
        .ForMember(dest => dest.SchoolId, opt => opt.Ignore());
    }
}