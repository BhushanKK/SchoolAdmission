using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class StudentFeesRepository(ApplicationDbContext context) : IStudentFeesRepository
{
    public async Task<int> SaveStudentFeesAsync(StudentFeesDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentFees;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PreviousYearFee", (object?)cmd.PreviousYearFee ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PreviousYearFeePaid", (object?)cmd.PreviousYearFeePaid ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@IsBusRequired", (object?)cmd.IsBusRequired ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@BusFee", (object?)cmd.BusFee ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@BusFeePaid", (object?)cmd.BusFeePaid ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@FeeExemption", (object?)cmd.FeeExemption ?? DBNull.Value));

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
