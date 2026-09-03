using System;
using System.Collections.Generic;
using System.Text;
using Desafio2_DES.Common;

namespace Desafio2_DES.BL.Interfaces
{
    public interface IOrganizadorService
    {
        Task<IEnumerable<OrganizadorDto>> GetAllAsync();
        Task<OrganizadorDto?> GetByIdAsync(int id);
        Task<OrganizadorDto> CreateAsync(CreateOrganizadorDto dto);
        Task<bool> UpdateAsync(int id, CreateOrganizadorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}