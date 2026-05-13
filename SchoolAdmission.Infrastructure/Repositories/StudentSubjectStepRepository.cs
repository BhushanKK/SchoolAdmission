using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StudentSubjectStepRepository(ApplicationDbContext context) : IStudentSubjectStepRepository
{
    public async Task<int> SaveStudentSubjectAsync(Guid studentId, CancellationToken ct)
    {
        int returnValue = 0;
        try
        {
            var connection = context.Database.GetDbConnection();

            await using var command = connection.CreateCommand();

            command.CommandText = StoreProcedureConstants.USP_StudentDetailsStep;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@StudentId", (object?)studentId ?? DBNull.Value));
            command.Parameters.Add(new SqlParameter("@Step", "Step6"));

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync(ct);

            returnValue = await command.ExecuteNonQueryAsync(ct);
            await connection.CloseAsync();
        }
        catch (Exception)
        {
            returnValue = -1;
        }
        return returnValue;
    }
}