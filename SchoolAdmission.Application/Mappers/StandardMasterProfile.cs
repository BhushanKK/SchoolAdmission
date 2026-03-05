using AutoMapper;
using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Mappings;

public class StandardMasterProfile : Profile
{
    public StandardMasterProfile()
    {
        CreateMap<StandardMasterDto, StandardMaster>()
        .ForMember(dest => dest.StandardId, opt => opt.Ignore());
    }
}