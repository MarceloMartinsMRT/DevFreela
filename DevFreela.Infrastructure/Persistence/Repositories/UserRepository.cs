using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDBContext _dbContext;

        public UserRepository(DevFreelaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserDTO(user.FullName, user.Email);
        }
        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

    }
}
