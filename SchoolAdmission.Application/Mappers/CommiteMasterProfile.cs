using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;
public class CommiteMasterProfile : Profile
{
    public CommiteMasterProfile()
    {
        CreateMap<CommiteMasterCommandDto, CommiteMaster>()
        .ForMember(dest => dest.CommiteeId, opt => opt.Ignore());
    }
}