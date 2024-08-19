using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;

namespace WebApi1.Mapping
{
    public class UserMap : IMapper<User,UserDTO>
    {
        public User Map(UserDTO userDTO)
        {
            return new User
            {
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Phone = userDTO.Phone,
                Surname = userDTO.Surname
            };
        }

        public UserDTO Map(User user)
        {
            return new UserDTO
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Surname = user.Surname
            };
        }

        public User UpdateMap(User user, UserDTO userDTO)
        {
            user.Surname = userDTO.Surname;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Phone = userDTO.Phone;
            user.Firstname = userDTO.Firstname;
            user.Lastname = userDTO.Lastname;
            return user;
        }

        public IEnumerable<UserDTO> MapList(IEnumerable<User> users)
        {
            List<UserDTO> result = new List<UserDTO>();
            foreach (User user in users)
            {
                result.Add(new UserDTO
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone,
                    Surname = user.Surname
                });
            }
            return result;
        }
    }
}
