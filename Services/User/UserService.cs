using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using WebApi1.DTO;
using WebApi1.Mapping;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Rpeository;

namespace WebApi1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User,UserDTO> _mapper;
        public UserService(IUserRepository userRepository, IMapper<User,UserDTO> userMapper)
        {
            _userRepository = userRepository;
            _mapper = userMapper;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = _mapper.Map(userDTO);
            await _userRepository.Add(user);
            return _mapper.Map(user);
        }

        public async Task<bool> Delete(long id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                await _userRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.MapList(users);
        }

        public async Task<UserDTO> GetById(long id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map(user);
        }

        public async Task<IEnumerable<UserDTO>> GetByName(string name)
        {
            var user = await _userRepository.GetByName(name);
            return _mapper.MapList(user);
        }

        public async Task<UserDTO> Update(long id, UserDTO userDTO)
        {
            var updateUser = await _userRepository.GetById(id);
            if (updateUser == null) throw new Exception("User not found");
            updateUser = _mapper.UpdateMap(updateUser, userDTO);
            await _userRepository.Update(updateUser);
            return _mapper.Map(updateUser);
        }

        public async Task<IEnumerable<UserDTO>> SortSearch(string sortOrder, string searchString)
        {
            var users=await _userRepository.GetAll();

            if (!String.IsNullOrEmpty(searchString)
                || searchString == " ")
            {
                users=users.Where(u=>
                u.Firstname.Contains(searchString)
                || u.Surname.Contains(searchString)
                || u.Lastname.Contains(searchString)
                || u.Email.Contains(searchString)
                || u.Phone.Contains(searchString))
                    .ToList();
            }

            switch (sortOrder)
            {
                case "FN":
                    users=users.OrderBy(u=>u.Firstname).ToList();
                    break;
                case "FN_desc":
                    users = users.OrderByDescending(u => u.Firstname).ToList();
                    break;
                case "SN":
                    users=users.OrderBy(u=>u.Surname).ToList();
                    break;
                case "SN_desc":
                    users = users.OrderByDescending(u => u.Surname).ToList();
                    break;
                case "LN":
                    users=users.OrderBy(u=>u.Lastname).ToList();
                    break;
                case "LN_desc":
                    users = users.OrderByDescending(u => u.Lastname).ToList();
                    break;
                default:
                    users=users.OrderByDescending(u=>u.Id).ToList();
                    break;
            }

            return _mapper.MapList(users);
        }
    }
}
