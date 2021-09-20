using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Application.Dtos;

namespace TesteTecnico.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        Task<int?> Add(UsuarioDto userDto);

        Task<bool> Update(UsuarioDto userDto);

        Task Delete(UsuarioDto userDto);

        Task<UsuarioDto> GetById(int id);

        Task<IEnumerable<UsuarioDto>> GetAll();
    }
}
