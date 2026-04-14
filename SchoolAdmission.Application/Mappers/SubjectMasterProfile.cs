using AutoMapper;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Application.Mappings;

public class SubjectMasterProfile : Profile
{
    public SubjectMasterProfile()
    {
        CreateMap<SubjectMasterCommandDto, SubjectMaster>()
        .ForMember(dest => dest.SubjectId, opt => opt.Ignore());
    }
}
