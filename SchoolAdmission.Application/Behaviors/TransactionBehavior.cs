using MediatR;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(ApplicationDbContext context) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Apply only to Commands
        if (!request.GetType().Name.EndsWith("Command"))
            return await next();

        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var response = await next(); // run the handler

            // Commit all changes in one transaction
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return response;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}