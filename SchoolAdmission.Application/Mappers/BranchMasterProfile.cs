using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Mappings;

public class BranchMasterProfile : Profile
{
    public BranchMasterProfile()
    {
        CreateMap<BranchMasterCommandDto, BranchMaster>()
        .ForMember(dest => dest.BranchId, opt => opt.Ignore());;
    }
}
