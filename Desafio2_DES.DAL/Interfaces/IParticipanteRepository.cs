using System;
using System.Collections.Generic;
using System.Text;
using Desafio2_DES.Entities;

namespace Desafio2_DES.DAL.Interfaces;

public interface IParticipanteRepository
{
    Task<IEnumerable<Participante>> GetAllAsync();
    Task<Participante> GetByIdAsync(int id);
    Task<int> CreateAsync(Participante participante);
    Task<bool> UpdateAsync(Participante participante);
    Task<bool> DeleteAsync(int id);
}
