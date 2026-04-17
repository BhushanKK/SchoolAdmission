using AutoMapper;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Application.Mappings;

public class StudentSubjectChoiceProfile : Profile
{
    public StudentSubjectChoiceProfile()
    {
        CreateMap<StudentSubjectChoiceCommandDto, StudentSubjectChoice>()
            .ForMember(dest => dest.ChoiceId, opt => opt.Ignore());
    }
}