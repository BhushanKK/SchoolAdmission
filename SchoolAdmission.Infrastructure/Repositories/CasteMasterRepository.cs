using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Application.Common.Interfaces;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CasteMasterRepository : ICasteMasterRepository
{
    private readonly ApplicationDbContext _context;

    public CasteMasterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CasteMaster>> GetAllAsync()
        => await _context.CasteMasters.ToListAsync();

    public async Task<CasteMaster?> GetByIdAsync(int id)
        => await _context.CasteMasters.FindAsync(id);

    public async Task AddAsync(CasteMaster caste)
        => await _context.CasteMasters.AddAsync(caste);

    public void Update(CasteMaster caste)
        => _context.CasteMasters.Update(caste);

    public void Delete(CasteMaster caste)
        => _context.CasteMasters.Remove(caste);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}