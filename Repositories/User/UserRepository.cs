using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.DTO;
using WebApi1.Mapping;
using WebApi1.Mappings;
using WebApi1.Models;

namespace WebApi1.Rpeository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           return await _context.Users
                .Where(u=>u.IsDeleted==false)
                .ToListAsync();
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetByName(string name)
        {
            return await _context.Users
                .Where(u=>u.Firstname.Contains(name)
                || u.Surname.Contains(name)
                || u.Lastname.Contains(name)
                && u.IsDeleted==false)
                .ToListAsync();
        }
        //public async Task<UserDTO> Create(UserDTO userDto)
        //{
        //    await _context.Users
        //        .AddAsync(_mapper.MapToUser(userDto));
        //    await _context.SaveChangesAsync();
        //    return userDto;
        //}

        //public async Task<bool> Delete(long id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user != null)
        //    {
        //        user.IsDeleted = true;
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<IEnumerable<UserDTO>> GetAll()
        //{
        //    return await _context.Users
        //        .Select(u => _mapper.MapToUserDTO(u))
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<UserDTO>> GetAllNotDeleted()
        //{
        //    return await _context.Users
        //        .Where(u=>u.IsDeleted==false)
        //        .Select(u=>_mapper.MapToUserDTO(u))
        //        .ToListAsync();
        //}

        //public async Task<UserDTO> GetById(long id)
        //{
        //    var user= await _context.Users
        //        .FindAsync(id);
        //    if(user!=null && user.IsDeleted == false)
        //    {
        //        return _mapper.MapToUserDTO(user);
        //    }
        //    return null;
        //}

        //public async Task<IEnumerable<UserDTO>> GetByName(string name)
        //{
        //    return await _context.Users
        //        .Where(u => u.Firstname.Contains(name)
        //        || u.Surname.Contains(name)
        //        || u.Lastname.Contains(name)
        //        && u.IsDeleted == false)
        //        .Select(u=>_mapper.MapToUserDTO(u))
        //        .ToListAsync();
        //}

        //public async Task<UserDTO> Update(long id, UserDTO userDto)
        //{
        //    var user=await _context.Users.FindAsync(id);
        //    user=_mapper.UpdateMapToUser(user,userDto);
        //    await _context.SaveChangesAsync();
        //    return _mapper.MapToUserDTO(user);
        //}
    }
}
