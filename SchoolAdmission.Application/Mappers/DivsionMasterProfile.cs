using AutoMapper;
//using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class DivisionMasterProfile : Profile
{
    public DivisionMasterProfile()
    {
        CreateMap<DivisionMasterCommandDto, DivisionMaster>()
        .ForMember(dest => dest.DivisionId, opt => opt.Ignore());
    }
}