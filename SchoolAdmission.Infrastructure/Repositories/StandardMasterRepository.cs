using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories
{
    public class StandardMasterRepository(ApplicationDbContext context) : IStandardMasterRepository
    {
        // Get all
        public async Task<List<StandardMaster>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.StandardMasters
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        // Get by Id
        public async Task<StandardMaster?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.StandardMasters
                .FindAsync(new object[] { id }, cancellationToken);
        }

        // Add
        public async Task<int> AddAsync(StandardMaster entity, CancellationToken cancellationToken = default)
        {
            await context.StandardMasters.AddAsync(entity, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken);
        }

        // Update
        public async Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken = default)
        {
            context.StandardMasters.Update(entity);
            return await context.SaveChangesAsync(cancellationToken);
        }

        // Delete
        public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await context.StandardMasters.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                context.StandardMasters.Remove(entity);
                return await context.SaveChangesAsync(cancellationToken);
            }
            return 0;
        }
    }
}