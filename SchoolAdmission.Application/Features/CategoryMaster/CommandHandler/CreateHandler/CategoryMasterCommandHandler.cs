using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;
public class CreateCategoryMasterHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateCategoryMasterCommand, int>
{
    public async Task<int> Handle(CreateCategoryMasterCommand request,CancellationToken cancellationToken)
    {
        var categoryMaster = mapper.Map<CategoryMaster>(request);
        await context.CategoryMasters.AddAsync(categoryMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return categoryMaster.categoryId;
    }
}