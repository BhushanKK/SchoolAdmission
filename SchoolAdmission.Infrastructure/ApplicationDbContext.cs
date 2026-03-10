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
    public DbSet<StandardMaster> StandardMasters => Set<StandardMaster>();
    public DbSet<DivisionMaster> DivisionMasters => Set<DivisionMaster>();
    public DbSet<BranchMaster> BranchMasters => Set<BranchMaster>();
    public DbSet<ReligionMaster> ReligionMasters => Set<ReligionMaster>();
    public DbSet<FeesStructureDetails> FeesStructureDetails => Set<FeesStructureDetails>();
    public DbSet<CommiteMaster> CommiteMasters => Set<CommiteMaster>();
    public DbSet<SchoolMaster> SchoolMasters => Set<SchoolMaster>();


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

        modelBuilder.Entity<DivisionMaster>(entity =>
        {
            entity.ToTable("DivisionMaster");
            entity.HasKey(e => e.DivisionId);
        });

        modelBuilder.Entity<ReligionMaster>(entity =>
        {
            entity.ToTable("ReligionMaster");
            entity.HasKey(e => e.ReligionId);
        });

        modelBuilder.Entity<BranchMaster>(entity =>
        {
            entity.ToTable("BranchMaster");
            entity.HasKey(e => e.BranchId);
        });

        modelBuilder.Entity<FeesStructureDetails>(entity =>
        {
            entity.ToTable("FeesStructureDetails");
            entity.HasKey(e => e.FeeId);
        });

        modelBuilder.Entity<CommiteMaster>(entity =>
        {
            entity.ToTable("CommiteMaster");
            entity.HasKey(e => e.CommiteeId);
        });

        modelBuilder.Entity<SchoolMaster>(entity =>
        {
            entity.ToTable("SchoolMaster");
            entity.HasKey(e => e.SchoolId);
        });

        base.OnModelCreating(modelBuilder);
    }
}