using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class ReligionMasterProfile : Profile
{
    public ReligionMasterProfile()
    {
        CreateMap<ReligionMasterCommandDto, ReligionMaster>()
        .ForMember(dest => dest.ReligionId, opt => opt.Ignore());
    }
}