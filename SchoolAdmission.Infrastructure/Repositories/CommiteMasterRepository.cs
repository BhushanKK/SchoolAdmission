using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CommiteMasterRepository : ICommiteMasterRepository
{
    private readonly ApplicationDbContext context;
    private readonly IEmailService _emailService;

    public CommiteMasterRepository(ApplicationDbContext context, IEmailService emailService)
    {
        this.context = context;
        _emailService = emailService;
    }

    public async Task<List<CommiteMaster>> GetAllAsyncEntities(CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<CommiteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var subject = "Registration Successful";
        
        var body = "<h2>Welcome!</h2><p>Registration successful.</p>";

        await _emailService.SendEmailAsync("kunalpagare1117@gmail.com", subject, body);
        
        return await context.CommiteMasters
            .AsNoTracking()
            .Select(x => new CommiteMasterQueryDto
            {
                CommiteeId = x.CommiteeId,
                CommiteeName = x.CommiteeName
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.CommiteMasters.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<CommiteMasterQueryDto?> GetByIdWithCommiteAsync(int id, CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .Where(x => x.CommiteeId == id)
            .Select(x => new CommiteMasterQueryDto
            {
                CommiteeId = x.CommiteeId,
                CommiteeName = x.CommiteeName
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task AddAsync(CommiteMaster division, CancellationToken cancellationToken)
    {
        await context.CommiteMasters.AddAsync(division, cancellationToken);
    }

    public async Task UpdateAsync(CommiteMaster division, CancellationToken cancellationToken)
    {
        context.CommiteMasters.Update(division);
    }
 
    public async Task DeleteAsync(CommiteMaster division, CancellationToken cancellationToken)
    {
        context.CommiteMasters.Remove(division);
    }

    public async Task<bool> IsExistsAsync(string CommiteeName, OperationType  operation, int? CommiteeId, CancellationToken cancellationToken)
    {
        if (operation == OperationType.Create)
            return await context.CommiteMasters.AnyAsync(x => x.CommiteeName.ToLower() == CommiteeName.ToLower(), cancellationToken);
        
        else if (operation == OperationType.Update)
            return await context.CommiteMasters.AnyAsync(x => x.CommiteeName.ToLower() == CommiteeName .ToLower() && x.CommiteeId != CommiteeId, cancellationToken);

        return false;
    }
}
