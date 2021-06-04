using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Domain.Core;
using RestApi.Services.DTO;
using RestApi.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService restaurantSerivce;
        private readonly UserManager<User> userManager;

        public RestaurantsController(IRestaurantService restaurantSerivce, UserManager<User> userManager)
        {
            this.restaurantSerivce = restaurantSerivce;
            this.userManager = userManager;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurants = await restaurantSerivce.GetAllAsync();
            var map = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Restaurant, RestaurantDto>();
                cfg.CreateMap<Location, LocationDto>();
            }).CreateMapper();

            var restaurantsDto = map.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDto.ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetById(int id)
        {
            var restaurant = await restaurantSerivce.GetByIdAsync(id);
            var map = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDto>();
                cfg.CreateMap<Location, LocationDto>();
            }).CreateMapper();

            var restaurantDto = map.Map<RestaurantDto> (restaurant);

            if (restaurant is null)
            {
                return NotFound();
            }

            return restaurantDto;
        }

        [Authorize, HttpPut, Route("create")]
        public async Task<IActionResult> Create([FromBody] RestaurantDto restaurant)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(User?.Identity?.Name);

                if (!(user is null))
                {
                    var map = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RestaurantDto, Restaurant>()
                            .ForMember(m => m.Id, opt => opt.Ignore())
                            .ForMember(m => m.User, opt => opt.MapFrom((s, d) => d.User = user));
                        cfg.CreateMap<LocationDto, Location>();
                    }).CreateMapper();

                    var model = map.Map<Restaurant>(restaurant);

                    await restaurantSerivce.CreateAsync(model);

                    return Created(string.Empty, model);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize, HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var restaurant = await restaurantSerivce.GetByIdAsync(id);

            if (restaurant is null)
            {
                return NotFound();
            }

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (restaurant.User.Id != user.Id)
            {
                return Forbid();
            }

            await restaurantSerivce.DeleteAsync(restaurant);

            return Ok();
        }
    }
}
