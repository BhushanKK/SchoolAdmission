using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class StandardMasterProfile : Profile
{
    public StandardMasterProfile()
    {
        CreateMap<StandardMasterCommandDto, StandardMaster>()
        .ForMember(dest => dest.StandardId, opt => opt.Ignore());
    }
}