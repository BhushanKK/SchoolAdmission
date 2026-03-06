using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<CasteMaster> CasteMasters => Set<CasteMaster>();
    public DbSet<CategoryMaster> CategoryMasters => Set<CategoryMaster>();
    public DbSet<BranchMaster> BranchMasters => Set<BranchMaster>();
    public DbSet<ReligionMaster> ReligionMasters => Set<ReligionMaster>();
    
    public DbSet<StandardMaster> StandardMasters => Set<StandardMaster>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CasteMaster>(entity =>
        {
            entity.ToTable("CasteMaster");
            entity.HasKey(e => e.CasteId);
        });

        modelBuilder.Entity<CategoryMaster>(entity =>
        {
            entity.ToTable("CategoryMaster");
            entity.HasKey(e => e.categoryId);
        });

        modelBuilder.Entity<StandardMaster>(entity =>
        {
            entity.ToTable("StandardMaster");
            entity.HasKey(e => e.StandardId);
        });

        modelBuilder.Entity<ReligionMaster>(entity =>
        {
            entity.ToTable("ReligionMaster");
            entity.HasKey(e => e.ReligionId);
        });

        base.OnModelCreating(modelBuilder);
    }
}