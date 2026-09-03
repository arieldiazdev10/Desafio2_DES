using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Desafio2_DES.Common;
using Desafio2_DES.DAL;
using Desafio2_DES.Entities;

namespace Desafio2_DES.BL;

public class OrganizadorService : IOrganizadorService
{
    private readonly IOrganizadorRepository _repository;
    private readonly IMapper _mapper;

    public OrganizadorService(IOrganizadorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrganizadorDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrganizadorDto>>(entities);
    }

    public async Task<OrganizadorDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<OrganizadorDto>(entity);
    }

    public async Task<OrganizadorDto> CreateAsync(CreateOrganizadorDto dto)
    {
        var entity = _mapper.Map<Organizador>(dto);
        entity.IdOrganizador = await _repository.CreateAsync(entity);
        return _mapper.Map<OrganizadorDto>(entity);
    }

    public async Task<bool> UpdateAsync(int id, CreateOrganizadorDto dto)
    {
        var entity = _mapper.Map<Organizador>(dto);
        entity.IdOrganizador = id;
        return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
