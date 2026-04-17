using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Utils;
using System.Net;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Application.Features.SubjectMasters.Commands;

public class CreateSubjectMasterHandler(
    IMapper mapper,
    ILogger<CreateSubjectMasterHandler> logger,
    ApplicationDbContext context,
    ISubjectMasterRepository subjectMasterRepository,
    ICurrentUserRepository currentUser
) : IRequestHandler<CreateSubjectMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(
        CreateSubjectMasterCommand request,
        CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await subjectMasterRepository.IsExistsAsync(
                request.SubjectName!,
                OperationType.Create,
                null,
                cancellationToken
            );

            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.SubjectName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }

            var subject = mapper.Map<SubjectMaster>(request);

            subject.EntryBy = await currentUser.Email;
            subject.EntryDate = DateTime.UtcNow;

            await context.Subjects.AddAsync(subject, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                subject.SubjectId,
                MessageHelper.CreatedSuccessfully(EntityEnum.SubjectMaster),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while creating SubjectMaster");
            return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.SubjectMaster), 
            HttpStatusCode.InternalServerError.GetHashCode());
        }
    }

}