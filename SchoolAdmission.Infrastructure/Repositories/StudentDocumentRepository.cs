using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class StudentDocumentRepository(ApplicationDbContext context) : IStudentDocumentRepository
{
    public async Task<int> SaveStudentDocumentAsync(StudentDocumentDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();
        
        command.CommandText = StoreProcedureConstants.StudentDocument;
        command.CommandType = CommandType.StoredProcedure;
        
        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@DocumentType", (object?)cmd.DocumentType ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@DocumentPath", (object?)cmd.DocumentPath ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@UploadedDate", (object?)cmd.UploadedDate ?? DBNull.Value));
        
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
    public async Task<List<StudentDocument>> GetByStudentIdAsync(Guid studentId,CancellationToken cancellationToken)
        => await context.StudentDocuments
            .Where(x => x.StudentId == studentId).ToListAsync(cancellationToken);
}
