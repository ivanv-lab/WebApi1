using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;

namespace WebApi1.Rpeository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserDTO>> GetAllNotDeleted();
        public Task<IEnumerable<UserDTO>> GetAll();
        public Task<UserDTO> GetById(long id);
        public Task<UserDTO> Update(long id, UserDTO userDto);
        public Task<UserDTO> Create(UserDTO userDto);
        public Task<IActionResult> Delete(long id);
        public Task<IEnumerable<UserDTO>> GetByName(string name);
    }
}
