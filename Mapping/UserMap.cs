using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mapping
{
    public class UserMap
    {
        public User MapToUser(UserDTO userDTO)
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

        public UserDTO MapToUserDTO(User user)
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

        public User UpdateMapToUser(User user,UserDTO userDTO)
        {
            user.Surname = userDTO.Surname;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Phone = userDTO.Phone;
            user.Firstname = userDTO.Firstname;
            user.Lastname = userDTO.Lastname;
            return user;
        }
    }
}
