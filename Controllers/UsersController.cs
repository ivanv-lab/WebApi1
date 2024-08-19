using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.DTO;
using WebApi1.Mapping;
using WebApi1.Models;
using WebApi1.Services;

namespace WebApi1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var usersDto = await _userService.GetAll();
            return Ok(usersDto);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(long id)
        {
            var userDto = await _userService.GetById(id);
            return Ok(userDto);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> SearchUsers(string name)
        {
            var users=await _userService.GetByName(name);
            return Ok(users);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, UserDTO userDto)
        {
            var updateUser=await _userService.Update(id, userDto);
            return Ok(updateUser);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        {
            var newUser=await _userService.Create(userDto);
            return Ok(newUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            bool res=await _userService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }
    }
}
