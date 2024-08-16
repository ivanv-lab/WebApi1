using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Mapping;
using WebApi1.Models;

namespace WebApi1.Rpeository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly UserMap _mapper;

        public UserRepository(ApplicationContext context, UserMap mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDTO> Create(UserDTO userDto)
        {
            try
            {
                await _context.Users
                    .AddAsync(_mapper.MapToUser(userDto));
                await _context.SaveChangesAsync();
                return userDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var user=await _context.Users.FindAsync(id);
            if (user != null)
            {
                try
                {
                    user.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllNotDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(long id, UserDTO userDto)
        {
            throw new NotImplementedException();
        }
    }
}
