using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class FeesStructureProfile : Profile
{
    public FeesStructureProfile()
    {
        CreateMap<FeesStructureCommandDto, FeesStructureDetails>()
        .ForMember(dest => dest.FeeId, opt => opt.Ignore());
    }
}
