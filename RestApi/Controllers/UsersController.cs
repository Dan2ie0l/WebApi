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
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await userManager.Users.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            string guid = id.ToString();
            var user = await userManager.FindByIdAsync(guid);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            string guid = id.ToString();
            var user = await userManager.FindByIdAsync(guid);

            if (user is null)
            {
                return NotFound();
            }

            await userManager.DeleteAsync(user);

            return Ok();
        }
    }
}
