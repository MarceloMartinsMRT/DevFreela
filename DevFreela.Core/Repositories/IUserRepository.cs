using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddAsync(User user);
    }
}
