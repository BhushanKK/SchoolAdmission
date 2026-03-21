using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

public class StudentUpdateRepository(ApplicationDbContext context) : IStudentUpdateRepository
{
    public async Task<int> UpdateStudentUsingSpAsync(UpdateStudentDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = "USP_UpdateStudentDetails";
        command.CommandType = CommandType.StoredProcedure;
        var efTransaction = context.Database.CurrentTransaction;
        if (efTransaction != null)
            command.Transaction = efTransaction.GetDbTransaction();
        command.Parameters.Add(new SqlParameter("@StudentId", cmd.StudentId));
        command.Parameters.Add(new SqlParameter("@RegistrationNo", (object?)cmd.RegistrationNo ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@SchoolId", (object?)cmd.SchoolId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@AcademicYearId", (object?)cmd.AcademicYearId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@FinancialYearId", (object?)cmd.FinancialYearId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@FirstName", (object?)cmd.FirstName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@MiddleName", (object?)cmd.MiddleName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@LastName", (object?)cmd.LastName ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Gender", cmd.Gender));
        command.Parameters.Add(new SqlParameter("@DOB", cmd.DOB));
        command.Parameters.Add(new SqlParameter("@SaralId", (object?)cmd.SaralId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@AadharNo", (object?)cmd.AadharNo ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Nationality", (object?)cmd.Nationality ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@MotherTongue", (object?)cmd.MotherTongue ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@ReligionId", (object?)cmd.ReligionId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CasteId", (object?)cmd.CasteId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CategoryId", (object?)cmd.CategoryId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@IsMinority", cmd.IsMinority));
        command.Parameters.Add(new SqlParameter("@IsHandicapped", cmd.IsHandicapped));
        command.Parameters.Add(new SqlParameter("@IsBpl", cmd.IsBpl));
        command.Parameters.Add(new SqlParameter("@BPL_Type", (object?)cmd.BPL_Type ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Photo", (object?)cmd.Photo ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@ModifyBy", (object?)cmd.ModifyBy ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@BranchId", (object?)cmd.BranchId ?? DBNull.Value));

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