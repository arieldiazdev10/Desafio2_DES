using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Desafio2_DES.Entities;
using Desafio2_DES.DAL.Interfaces;

namespace Desafio2_DES.DAL;

public class ParticipanteRepository : IParticipanteRepository
{
    private readonly string _connectionString;

    public ParticipanteRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public async Task<IEnumerable<Participante>> GetAllAsync()
    {
        using var connection = CreateConnection();
        const string sql = @"SELECT id_participante AS IdParticipante,
                                     nombre AS Nombre,
                                     email AS Email,
                                     id_evento AS IdEvento
                              FROM Participantes";
        return await connection.QueryAsync<Participante>(sql);
    }

    public async Task<Participante?> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();
        const string sql = @"SELECT id_participante AS IdParticipante,
                                     nombre AS Nombre,
                                     email AS Email,
                                     id_evento AS IdEvento
                              FROM Participantes WHERE id_participante = @Id";
        return await connection.QueryFirstOrDefaultAsync<Participante>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Participante participante)
    {
        using var connection = CreateConnection();
        const string sql = @"INSERT INTO Participantes (nombre, email, id_evento)
                              VALUES (@Nombre, @Email, @IdEvento);
                              SELECT CAST(SCOPE_IDENTITY() as int);";
        return await connection.ExecuteScalarAsync<int>(sql, participante);
    }

    public async Task<bool> UpdateAsync(Participante participante)
    {
        using var connection = CreateConnection();
        const string sql = @"UPDATE Participantes
                              SET nombre = @Nombre, email = @Email, id_evento = @IdEvento
                              WHERE id_participante = @IdParticipante";
        var rows = await connection.ExecuteAsync(sql, participante);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = CreateConnection();
        const string sql = "DELETE FROM Participantes WHERE id_participante = @Id";
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}