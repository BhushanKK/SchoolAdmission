using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories
{
    public class StandardMasterRepository : IStandardMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public StandardMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all
        public async Task<List<StandardMaster>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.StandardMasters
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        // Get by Id
        public async Task<StandardMaster?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.StandardMasters
                .FindAsync(new object[] { id }, cancellationToken);
        }

        // Add
        public async Task<int> AddAsync(StandardMaster entity, CancellationToken cancellationToken = default)
        {
            await _context.StandardMasters.AddAsync(entity, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        // Update
        public async Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken = default)
        {
            _context.StandardMasters.Update(entity);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        // Delete
        public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.StandardMasters.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                _context.StandardMasters.Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            return 0;
        }
    }
}