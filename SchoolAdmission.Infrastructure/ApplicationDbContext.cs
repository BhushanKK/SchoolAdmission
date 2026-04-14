using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Entities;


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
    public DbSet<StudentDetails> StudentDetails => Set<StudentDetails>();
    public DbSet<StudentAddresses> StudentAddresses => Set<StudentAddresses>();
    public DbSet<StudentParents> StudentParents => Set<StudentParents>();
    public DbSet<StudentHealth> StudentHealths => Set<StudentHealth>();
    public DbSet<StudentDocument> StudentDocuments => Set<StudentDocument>();
    public DbSet<SubjectMaster> Subjects => Set<SubjectMaster>();
    public DbSet<StudentFees> StudentFees => Set<StudentFees>();
    public DbSet<StudentAcademicHistory> StudentAcademicHistorys => Set<StudentAcademicHistory>();
    public DbSet<Roles> Roles => Set<Roles>();
    public DbSet<Administration> Administrations => Set<Administration>();
    public DbSet<UsersLogin> UsersLogins => Set<UsersLogin>();

    public DbSet<StudentDetailsView> StudentDetailsView { get; set; }
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

        modelBuilder.Entity<SubjectMaster>(entity =>
        {
            entity.ToTable("Subjects");
            entity.HasKey(e => e.SubjectId);
        });

        modelBuilder.Entity<StudentDetails>(entity =>
        {
            entity.ToTable("StudentDetails");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<StudentHealth>(entity =>
        {
            entity.ToTable("StudentHealths");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<StudentParents>(entity =>
        {
            entity.ToTable("StudentParents");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<StudentAddresses>(entity =>
        {
            entity.ToTable("StudentAddresses");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<StudentDocument>(entity =>
        {
            entity.ToTable("StudentDocuments");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<StudentFees>(entity =>
        {
            entity.ToTable("StudentFees");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<StudentAcademicHistory>(entity =>
        {
            entity.ToTable("StudentAcademicHistory");
            entity.HasKey(e => e.StudentId);
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.ToTable("Roles");
            entity.HasKey(e => e.RoleId);
        });

        modelBuilder.Entity<Administration>(entity =>
        {
            entity.ToTable("Administration");
            entity.HasKey(e => e.AdminId);
        });

        modelBuilder.Entity<UsersLogin>(entity =>
        {
            entity.ToTable("UsersLogin");
            entity.HasKey(e => e.UserId);
        });

        modelBuilder.Entity<StudentDetailsView>()
        .HasNoKey()
        .ToView("StudentDetailsView");

        base.OnModelCreating(modelBuilder);
    }
}
