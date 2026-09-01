using AutoMapper;
using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.DAL.Interfaces;
using Desafio2_DES.Entities.DTO;
using Desafio2_DES.Entities.Models;

namespace Desafio2_DES.BL
{
    public class EventoService(IEventoRepository eventoRepository, IMapper mapper) : IEventoService
    {
        public async Task<List<EventoDto>> GetEventosAsync()
        {
            var eventos = await eventoRepository.GetEventosAsync();
            return mapper.Map<List<EventoDto>>(eventos);
        }

        public async Task<EventoDto?> GetEventoByIdAsync(int id)
        {
            var evento = await eventoRepository.GetEventoByIdAsync(id);
            return mapper.Map<EventoDto?>(evento);
        }


        public async Task<EventoDto> InsertEventoAsync(EventoDto evento)
        {
            var entity = mapper.Map<Evento>(evento);
            var newId = await eventoRepository.InsertEventoAsync(entity);
            evento.CodigoEvento = newId;
            return evento;
        }

        public async Task<EventoDto?> UpdateEventoAsync(int id, EventoDto evento)
        {
            var entity = mapper.Map<Evento>(evento);
            entity.IdEvento = id;
            var updated = await eventoRepository.UpdateEventoAsync(entity);
            if(!updated)
            {
                return null;
            }
            evento.CodigoEvento = id;
            return evento;
        }

        public  async Task<bool> DeleteEventoAsync(int id)
        {
            return await eventoRepository.DeleteEventoAsync(id);
        }
    }
}
