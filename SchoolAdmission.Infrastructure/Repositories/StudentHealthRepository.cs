using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

public class StudentHealthRepository(ApplicationDbContext context) : IStudentHealthRepository
{
    public async Task<int> SaveStudentHealthAsync(StudentHealthDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentHealth; 
        command.CommandType = CommandType.StoredProcedure;

        var efTransaction = context.Database.CurrentTransaction;
        if (efTransaction != null)
            command.Transaction = efTransaction.GetDbTransaction();

        
        command.Parameters.Add(new SqlParameter("@HealthId", (object?)cmd.HealthId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Height", (object?)cmd.Height ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Weight", (object?)cmd.Weight ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@HandicappedTypeId", (object?)cmd.HandicappedTypeId ?? DBNull.Value));

        
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
