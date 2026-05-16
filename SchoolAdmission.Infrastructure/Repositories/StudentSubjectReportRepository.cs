using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class StudentSubjectReportRepository(ApplicationDbContext context) 
    : IStudentSubjectReportRepository
{
    public async Task<List<StudentSubjectReport>> GetAllStudentSubjectsAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var connection = context.Database.GetDbConnection();
        await using var command = connection.CreateCommand();
        command.CommandText = StoreProcedureConstants.USP_GetStudentSubjectReport;
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@StudentId", (object?)studentId ?? DBNull.Value));
        await connection.OpenAsync(cancellationToken);
        var reader = await command.ExecuteReaderAsync(cancellationToken);
        var studentSubjects = new List<StudentSubjectReport>();
        while (await reader.ReadAsync(cancellationToken))
        {
            studentSubjects.Add(new StudentSubjectReport
            {
                BranchName = reader["BranchName"] as string,
                GroupName = reader["GroupName"] as string,
                SubjectName = reader["SubjectName"] as string
            });
        }
        await reader.CloseAsync();
        await connection.CloseAsync();
        return studentSubjects;
    }
}
