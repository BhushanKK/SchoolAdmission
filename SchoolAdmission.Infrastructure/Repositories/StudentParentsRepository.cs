using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class StudentParentRepository(ApplicationDbContext context) : IStudentParentsRepository
{
    public async Task<int> SaveStudentParentsAsync(StudentParentsDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentParents; 
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@FatherName", (object?)cmd.FatherName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@MotherName", (object?)cmd.MotherName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@GrandFatherName", (object?)cmd.GrandFatherName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@ParentName", (object?)cmd.ParentName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@ContactNo", (object?)cmd.ContactNo ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@EmailId", (object?)cmd.EmailId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Income", (object?)cmd.Income ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Occupation", (object?)cmd.Occupation ?? DBNull.Value));

        var resultParam = new SqlParameter("@Result", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(resultParam);

        
        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(ct);

        await command.ExecuteNonQueryAsync(ct);

        var result = (int)(resultParam.Value ?? 0);

        await connection.CloseAsync();

        return result;
    }
    
    public async Task<StudentParents?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    => await context.StudentParents
        .FirstOrDefaultAsync(x => x.StudentId == studentId, cancellationToken);
}
