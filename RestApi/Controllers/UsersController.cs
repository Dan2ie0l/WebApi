using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Core;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> users;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (id != user.Id)
            {
                return BadRequest();
            }

            User entity = await _context.Users.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                entity.Phone = user.Phone;
                entity.Email = user.Email;
                entity.Role = user.Role;
                await _context.SaveChangesAsync();

            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw new Exception("Can't Save");
                
            }

            return CreatedAtAction("GetUser", new { id = entity.Id }, entity);
        }
    


    

       
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            User users = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            User user1 = new User { FirstName = user.FirstName, LastName = user.LastName, Phone = user.Phone, Role = user.Role, Email = user.Email, Password = BCrypt.Net.BCrypt.HashPassword(user.Password) };

            if (users == null)
            {
                _context.Users.Add(user1);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("ErrorExsistingUser");

            return CreatedAtAction("GetUser", new { id = user1.Id }, user1);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
