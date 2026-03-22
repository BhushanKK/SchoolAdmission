using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

public class StudentAddressesRepository(ApplicationDbContext context) : IStudentAddressesRepository
{
    public async Task<int> SaveStudentAddressesAsync(StudentAddressesDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentAddresses; // ✅ SP Name
        command.CommandType = CommandType.StoredProcedure;

        var efTransaction = context.Database.CurrentTransaction;
        if (efTransaction != null)
            command.Transaction = efTransaction.GetDbTransaction();

        // ✅ PARAMETERS (MATCH WITH SP)
        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@AddressType", (object?)cmd.AddressType ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Village", (object?)cmd.Village ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@City", (object?)cmd.City ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Taluka", (object?)cmd.Taluka ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@District", (object?)cmd.District ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@State", (object?)cmd.State ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Country", (object?)cmd.Country ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Pincode", (object?)cmd.Pincode ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@Landmark", (object?)cmd.Landmark ?? DBNull.Value));

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