using MediatR;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class CreateStandardMasterCommand :  StandardMasterDto,IRequest<int>;