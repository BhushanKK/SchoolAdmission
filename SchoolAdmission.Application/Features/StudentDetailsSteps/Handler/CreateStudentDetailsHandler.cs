using SchoolAdmission.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;
using AutoMapper;
using SchoolAdmission.Infrastructure.Data;
using MediatR;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Application.Features.StudentDetailsSteps.Commands;
public class CreateStudentDetailsHandler(ILogger<CreateStudentDetailsHandler> logger, ApplicationDbContext context) : IRequestHandler<CreateStudentDetailsStepsCommand, ApiResponse<Guid>>
{
    public async Task<ApiResponse<Guid>> Handle(CreateStudentDetailsStepsCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var studentDetailsStep = new StudentDetailsStep();
            studentDetailsStep?.StudentId = request.StudentId;
            studentDetailsStep?.Step1= request.Step1;
            studentDetailsStep?.Step2= request.Step2;
            studentDetailsStep?.Step3= request.Step3;
            studentDetailsStep?.Step4= request.Step4;
            studentDetailsStep?.Step5= request.Step5;
            studentDetailsStep?.Step6= request.Step6;
            studentDetailsStep?.Step7= request.Step7;

            await context.StudentDetailsSteps.AddAsync(studentDetailsStep!, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<Guid>.SuccessResponse(studentDetailsStep!.StudentId, MessageHelper.CreatedSuccessfully(EntityEnum.StudentDetailsSteps), HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex.Message, "Failed to create StudentDetailsSteps");
            return ApiResponse<Guid>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.StudentDetailsSteps), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}

