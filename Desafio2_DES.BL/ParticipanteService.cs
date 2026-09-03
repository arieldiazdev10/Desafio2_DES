using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Desafio2_DES.Common;
using Desafio2_DES.DAL;
using Desafio2_DES.Entities;
using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.DAL.Interfaces;

namespace Desafio2_DES.BL;

public class ParticipanteService : IParticipanteService
{
    private readonly IParticipanteRepository _repository;
    private readonly IMapper _mapper;

    public ParticipanteService(IParticipanteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ParticipanteDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ParticipanteDto>>(entities);
    }

    public async Task<ParticipanteDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<ParticipanteDto>(entity);
    }

    public async Task<ParticipanteDto> CreateAsync(CreateParticipanteDto dto)
    {
        var entity = _mapper.Map<Participante>(dto);
        entity.IdParticipante = await _repository.CreateAsync(entity);
        return _mapper.Map<ParticipanteDto>(entity);
    }

    public async Task<bool> UpdateAsync(int id, CreateParticipanteDto dto)
    {
        var entity = _mapper.Map<Participante>(dto);
        entity.IdParticipante = id;
        return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
