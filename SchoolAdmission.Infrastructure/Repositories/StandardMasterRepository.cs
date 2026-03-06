using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories
{
<<<<<<< HEAD
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
=======
    public class StandardMasterRepository(ApplicationDbContext context) : IStandardMasterRepository
    {
        // Get all
        public async Task<List<StandardMaster>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.StandardMasters
>>>>>>> 95a61daef0f3d45e58a621ab56374c1d8bee44f4
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        // Get by Id
        public async Task<StandardMaster?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            return await _context.StandardMasters
=======
            return await context.StandardMasters
>>>>>>> 95a61daef0f3d45e58a621ab56374c1d8bee44f4
                .FindAsync(new object[] { id }, cancellationToken);
        }

        // Add
        public async Task<int> AddAsync(StandardMaster entity, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            await _context.StandardMasters.AddAsync(entity, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
=======
            await context.StandardMasters.AddAsync(entity, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken);
>>>>>>> 95a61daef0f3d45e58a621ab56374c1d8bee44f4
        }

        // Update
        public async Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            _context.StandardMasters.Update(entity);
            return await _context.SaveChangesAsync(cancellationToken);
=======
            context.StandardMasters.Update(entity);
            return await context.SaveChangesAsync(cancellationToken);
>>>>>>> 95a61daef0f3d45e58a621ab56374c1d8bee44f4
        }

        // Delete
        public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            var entity = await _context.StandardMasters.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                _context.StandardMasters.Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);
=======
            var entity = await context.StandardMasters.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                context.StandardMasters.Remove(entity);
                return await context.SaveChangesAsync(cancellationToken);
>>>>>>> 95a61daef0f3d45e58a621ab56374c1d8bee44f4
            }
            return 0;
        }
    }
}