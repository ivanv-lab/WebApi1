using WebApi1.Models;

namespace WebApi1.Rpeository
{
    public interface IUserRepository
    {
        public Task<User> GetById(long id);
        public Task<IEnumerable<User>> GetAll();
        public Task Add(User user);
        public Task Update(User user);
        public Task Delete(long id);
        public Task<IEnumerable<User>> GetByName(string name);
    }
}
