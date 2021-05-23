
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Register(User user)
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



    }
}
