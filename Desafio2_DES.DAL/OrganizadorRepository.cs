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

public class OrganizadorRepository : IOrganizadorRepository
{
    private readonly string _connectionString;

    public OrganizadorRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public async Task<IEnumerable<Organizador>> GetAllAsync()
    {
        using var connection = CreateConnection();
        const string sql = @"SELECT id_organizador AS IdOrganizador,
                                     nombre AS Nombre,
                                     cargo AS Cargo,
                                     id_evento AS IdEvento
                              FROM Organizadores";
        return await connection.QueryAsync<Organizador>(sql);
    }

    public async Task<Organizador?> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();
        const string sql = @"SELECT id_organizador AS IdOrganizador,
                                     nombre AS Nombre,
                                     cargo AS Cargo,
                                     id_evento AS IdEvento
                              FROM Organizadores WHERE id_organizador = @Id";
        return await connection.QueryFirstOrDefaultAsync<Organizador>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Organizador organizador)
    {
        using var connection = CreateConnection();
        const string sql = @"INSERT INTO Organizadores (nombre, cargo, id_evento)
                              VALUES (@Nombre, @Cargo, @IdEvento);
                              SELECT CAST(SCOPE_IDENTITY() as int);";
        return await connection.ExecuteScalarAsync<int>(sql, organizador);
    }

    public async Task<bool> UpdateAsync(Organizador organizador)
    {
        using var connection = CreateConnection();
        const string sql = @"UPDATE Organizadores
                              SET nombre = @Nombre, cargo = @Cargo, id_evento = @IdEvento
                              WHERE id_organizador = @IdOrganizador";
        var rows = await connection.ExecuteAsync(sql, organizador);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = CreateConnection();
        const string sql = "DELETE FROM Organizadores WHERE id_organizador = @Id";
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}
