using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;

public class StudentAcademicHistoryRepository(ApplicationDbContext context) 
    : IStudentAcademicHistoryRepository
{
    public async Task<int> SaveStudentAcademicHistoryAsync(StudentAcademicHistoryDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();
        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentAcademicHistory;
        command.CommandType = CommandType.StoredProcedure;

        var efTransaction = context.Database.CurrentTransaction;
        if (efTransaction != null)
            command.Transaction = efTransaction.GetDbTransaction();

        // PARAMETERS
        command.Parameters.Add(new SqlParameter("@AcademicHistoryId", (object?)cmd.AcademicHistoryId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PreviousSchool", (object?)cmd.PreviousSchool ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@SchoolDOE", (object?)cmd.SchoolDOE ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Progress", (object?)cmd.Progress ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Behaviour", (object?)cmd.Behaviour ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PassingYear", (object?)cmd.PassingYear ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@SeatNo", (object?)cmd.SeatNo ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@TotalMarks", (object?)cmd.TotalMarks ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Percentage", (object?)cmd.Percentage ?? DBNull.Value));

        // OUTPUT
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