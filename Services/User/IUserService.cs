using WebApi1.DTO;

namespace WebApi1.Services
{
    public interface IUserService
    {
        public Task<UserDTO> GetById(long id);
        public Task<IEnumerable<UserDTO>> GetByName(string name);
        public Task<IEnumerable<UserDTO>> GetAll();
        public Task<UserDTO> Create(UserDTO userDTO);
        public Task<UserDTO> Update(long id, UserDTO userDTO);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<UserDTO>> SortSearch(string sortOrder,
            string searchString);
    }
}
