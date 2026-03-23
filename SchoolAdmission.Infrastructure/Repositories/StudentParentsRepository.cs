using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

public class StudentParentRepository(ApplicationDbContext context) : IStudentParentsRepository
{
    public async Task<int> SaveStudentParentUsingSpAsync(StudentParentsDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentParents; 
        command.CommandType = CommandType.StoredProcedure;

        var efTransaction = context.Database.CurrentTransaction;
        if (efTransaction != null)
            command.Transaction = efTransaction.GetDbTransaction();

        
        command.Parameters.Add(new SqlParameter("@ParentId", (object?)cmd.ParentId ?? DBNull.Value));
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
}
