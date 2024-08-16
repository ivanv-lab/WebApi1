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

namespace WebApi1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserMap _userMapping;

        public UsersController(ApplicationContext context, UserMap userMap)
        {
            _context = context;
            _userMapping = userMap;
        }

        // GET: api/Users/NotDeleted
        [HttpGet]
        [Route("NotDeleted")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersNotDeted()
        {
            return await _context.Users
                .Where(u=>u.IsDeleted==false)
                .Select(u=>_userMapping.MapToUserDTO(u))
                .ToListAsync();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _context.Users
                .Select(u=>_userMapping.MapToUserDTO(u))
                .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return _userMapping.MapToUserDTO(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, UserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var user=await _context.Users.FindAsync(id);
                user = _userMapping.UpdateMapToUser(user, userDto);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            try
            {
                await _context.Users
                    .AddAsync(_userMapping.MapToUser(userDto));
                await _context.SaveChangesAsync();
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user=await _context.Users.FindAsync(id);
            if(user == null)
                return NotFound();
            try
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
