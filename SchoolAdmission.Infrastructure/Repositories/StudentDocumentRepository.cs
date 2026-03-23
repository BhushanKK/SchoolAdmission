using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;

public class StudentDocumentRepository(ApplicationDbContext context) : IStudentDocumentRepository
{
    public async Task<int> SaveStudentDocumentAsync(StudentDocumentDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        // ✅ Stored Procedure Name
        command.CommandText = StoreProcedureConstants.StudentDocument;
        command.CommandType = CommandType.StoredProcedure;

        // ✅ Transaction (same as your code)
        var efTransaction = context.Database.CurrentTransaction;
        if (efTransaction != null)
            command.Transaction = efTransaction.GetDbTransaction();

        // ✅ PARAMETERS
        command.Parameters.Add(new SqlParameter("@DocumentId", (object?)cmd.DocumentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@DocumentType", (object?)cmd.DocumentType ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@DocumentPath", (object?)cmd.DocumentPath ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@UploadedDate", (object?)cmd.UploadedDate ?? DBNull.Value));

        // ✅ OUTPUT PARAM
        var resultParam = new SqlParameter("@Result", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(resultParam);

        // ✅ OPEN CONNECTION
        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(ct);

        await command.ExecuteNonQueryAsync(ct);

        var result = (int)(resultParam.Value ?? 0);

        await connection.CloseAsync();

        return result;
    }
}