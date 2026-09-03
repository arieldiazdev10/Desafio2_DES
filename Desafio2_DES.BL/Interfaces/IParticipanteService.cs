using System;
using System.Collections.Generic;
using System.Text;
using Desafio2_DES.Common;

namespace Desafio2_DES.BL.Interfaces
{
    public interface IParticipanteService
    {
        Task<IEnumerable<ParticipanteDto>> GetAllAsync();
        Task<ParticipanteDto?> GetByIdAsync(int id);
        Task<ParticipanteDto> CreateAsync(CreateParticipanteDto dto);
        Task<bool> UpdateAsync(int id, CreateParticipanteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
