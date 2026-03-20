using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class FeesStructureDetailProfile : Profile
{
    public FeesStructureDetailProfile()
    {
        CreateMap<FeesStructureDetailCommandDto, FeesStructureDetail>()
        .ForMember(dest => dest.FeeId, opt => opt.Ignore());
    }
}