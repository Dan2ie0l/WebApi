
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
using RestApi.Implementations.Data;
using RestApi.Domain.Core;
using RestApi.Services.DTO.User;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthUserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            User users = await userManager.FindByEmailAsync(user.Email);
            User user1 = new User();
            
            if (users == null)
            {    
                await userManager.CreateAsync(user1);
            }
            else
                throw new Exception("ErrorExsistingUser");

            return CreatedAtAction("GetUser", new { id = user1.Id }, user1);
        }
    }
}
