using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestApi.Domain.Core;
using RestApi.Services.DTO.User;
using AutoMapper;
using RestApi.Services.Interfaces;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IJWTGenerator generator;

        public AuthUserController(UserManager<User> userManager, SignInManager<User> signInManager, IJWTGenerator generator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.generator = generator;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
            if (ModelState.IsValid)
            {
                var checkUser = await userManager.FindByEmailAsync(user.Email);

                if (checkUser is null)
                {
                    var map = new MapperConfiguration(cfg => cfg.CreateMap<UserRegisterDto, User>()
                                                                .ForMember(t => t.PasswordHash, opt => opt.Ignore()))
                                                                .CreateMapper();
                    var resultUser = map.Map<User>(user);


                    await userManager.CreateAsync(resultUser, user.Password);

                    return Ok();
                }
                else
                {
                    ModelState.AddModelError(nameof(user.Email), "Account with this email was already registered");
                    return BadRequest(ModelState);
                }
            }
            else return BadRequest(ModelState);
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userDto.Login);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(userDto.Login, userDto.Password, userDto.RememberMe, false);

                    if (result.Succeeded)
                    {
                        string token = generator.GenerateTokenForUser(user);

                        var response = new {
                            token
                        };

                        return Ok(response);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid password");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username");
                    return BadRequest(ModelState);
                }
            }
            else return BadRequest(ModelState);
        }

    }
}
