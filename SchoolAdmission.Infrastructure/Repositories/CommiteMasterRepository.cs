using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories
{
    public class CommiteMasterRepository : ICommiteMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public CommiteMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all CommiteMasters as entities
        public async Task<List<CommiteMaster>> GetAllAsyncEntities(CancellationToken cancellationToken)
        {
            return await _context.CommiteMasters
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        // Get all CommiteMasters as DTOs
        public async Task<List<CommiteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.CommiteMasters
                .AsNoTracking()
                .Select(x => new CommiteMasterQueryDto
                {
                    CommiteeId = x.CommiteeId,
                    CommiteeName = x.CommiteeName
                })
                .ToListAsync(cancellationToken);
        }

        // Get by ID as entity
        public async Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.CommiteMasters
                .FindAsync(new object[] { id }, cancellationToken);
        }

        // Get by ID as DTO
        public async Task<CommiteMasterQueryDto?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.CommiteMasters
                .Where(x => x.CommiteeId == id)
                .Select(x => new CommiteMasterQueryDto
                {
                    CommiteeId = x.CommiteeId,
                    CommiteeName = x.CommiteeName
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        // Add new CommiteMaster
        public async Task AddAsync(CommiteMaster division, CancellationToken cancellationToken)
        {
            await _context.CommiteMasters.AddAsync(division, cancellationToken);
        }

        // Update existing CommiteMaster
        public void Update(CommiteMaster division)
        {
            _context.CommiteMasters.Update(division);
        }

        // Delete CommiteMaster
        public void Delete(CommiteMaster division)
        {
            _context.CommiteMasters.Remove(division);
        }

        public async Task<bool> IsExistsAsync(string CommiteeName, CancellationToken cancellationToken)
        {
            return await _context.CommiteMasters
            .AnyAsync(x => x.CommiteeName == CommiteeName, cancellationToken);
        }

        // Optional: implement later if needed
        public Task<CommiteMasterQueryDto?> GetByIdWithCommiteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(CommiteMaster commite, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CommiteMaster commite, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}