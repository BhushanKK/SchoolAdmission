using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;

namespace SchoolAdmission.Application.Mappings;

public class CommiteMasterProfile : Profile
{
    public CommiteMasterProfile()
    {
        
        CreateMap<CreateCommiteMasterCommand, CommiteMaster>();

        
        CreateMap<UpdateCommiteMasterCommand, CommiteMaster>();
    }
}