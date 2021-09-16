using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Application.Dtos;

namespace TesteTecnico.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        Task<int?> Add(UserDto userDto);

        Task<bool> Update(UserDto userDto);

        Task Delete(UserDto userDto);

        Task<UserDto> GetById(int id);

        Task<IEnumerable<UserDto>> GetAll();
    }
}
