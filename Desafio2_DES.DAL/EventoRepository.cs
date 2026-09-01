using Desafio2_DES.DAL.Interfaces;
using Desafio2_DES.Entities.Models;

namespace Desafio2_DES.DAL
{
    public class EventoRepository(IDatabaseRepository databaseRepository) : IEventoRepository
    {
        private static class Queries
        {
            public const string GetAll = @"
                SELECT id_evento AS IdEvento, 
                       nombre AS Nombre, 
                       fecha AS Fecha, 
                       lugar AS Lugar 
                FROM Eventos";

            public const string GetById = @"
                SELECT id_evento AS IdEvento, 
                       nombre AS Nombre, 
                       fecha AS Fecha, 
                       lugar AS Lugar 
                FROM Eventos 
                WHERE id_evento = @Id";

            public const string Insert = @"
                INSERT INTO Eventos (nombre, fecha, lugar) 
                VALUES (@Nombre, @Fecha, @Lugar); 
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            public const string Update = @"
                UPDATE Eventos 
                SET nombre = @Nombre, 
                    fecha = @Fecha, 
                    lugar = @Lugar 
                WHERE id_evento = @IdEvento";

            public const string Delete = "DELETE FROM Eventos WHERE id_evento = @Id";
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            return [.. (await databaseRepository.QueryAsync<Evento>(Queries.GetAll))];
        }

        public async Task<Evento?> GetEventoByIdAsync(int id)
        {
            return await databaseRepository.QueryFirstOrDefaultAsync<Evento>(Queries.GetById, new { Id = id });
        }

        public async Task<int> InsertEventoAsync(Evento evento)
        {
            return await databaseRepository.ExecuteScalarAsync<int>(
                Queries.Insert,
                new { evento.Nombre, evento.Fecha, evento.Lugar }
            );
        }

        public async Task<bool> UpdateEventoAsync(Evento evento)
        {
            var rowsAffected = await databaseRepository.ExecuteAsync(
                Queries.Update,
                new { evento.Nombre, evento.Fecha, evento.Lugar, evento.IdEvento }
            );
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            return await databaseRepository.ExecuteAsync(Queries.Delete, new { Id = id }) > 0;
        }
    }
}