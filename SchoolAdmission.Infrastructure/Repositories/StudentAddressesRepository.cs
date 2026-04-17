using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;
public class StudentAddressesRepository(ApplicationDbContext context) : IStudentAddressesRepository
{
    public async Task<int> SaveStudentAddressesAsync(StudentAddressesDto cmd, CancellationToken ct)
    {
        var connection = context.Database.GetDbConnection();

        await using var command = connection.CreateCommand();

        command.CommandText = StoreProcedureConstants.StudentAddresses;
        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.Add(new SqlParameter("@StudentId", (object?)cmd.StudentId ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CVillage", (object?)cmd.CVillage ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CCity", (object?)cmd.CCity ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CTaluka", (object?)cmd.CTaluka ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CDistrict", (object?)cmd.CDistrict ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CState", (object?)cmd.CState ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CCountry", (object?)cmd.CCountry ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CPincode", (object?)cmd.CPincode ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@CLandmark", (object?)cmd.CLandmark ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PVillage", (object?)cmd.PVillage ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PCity", (object?)cmd.PCity ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PTaluka", (object?)cmd.PTaluka ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PDistrict", (object?)cmd.PDistrict ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PState", (object?)cmd.PState ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PCountry", (object?)cmd.PCountry ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PPincode", (object?)cmd.PPincode ?? DBNull.Value));
        command.Parameters.Add(new SqlParameter("@PLandmark", (object?)cmd.PLandmark ?? DBNull.Value));

        command.Parameters.Add(new SqlParameter("@IsSameAddress", (object?)cmd.IsSameAddress ?? DBNull.Value));

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