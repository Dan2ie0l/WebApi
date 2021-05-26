using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RestaurantsController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurant()
        {
            return await _context.Restaurant.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            Restaurant rest = await _context.Restaurant.FindAsync(id);
            if (rest == null)
            {
                return NotFound();
            }
            else
            {
                rest.Name = restaurant.Name;
                rest.Password = BCrypt.Net.BCrypt.HashPassword(restaurant.Password);
                rest.Phone1 = restaurant.Phone1;
                rest.Phone2 = restaurant.Phone2;
                rest.Description = restaurant.Description;
                rest.Location = restaurant.Location;
                rest.SocialMedia = restaurant.SocialMedia;
                rest.Website = restaurant.Website;
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

            return CreatedAtAction("GetRestaurant", new { id = rest.Id }, rest);
        }

     
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            Restaurant restaurants = await _context.Restaurant.FirstOrDefaultAsync(u => u.Name == restaurant.Name);
            Restaurant res1 = new Restaurant { Name = restaurant.Name, Phone1 = restaurant.Phone1, Phone2 = restaurant.Phone2, Description = restaurant.Description, Website = restaurant.Website, Password = BCrypt.Net.BCrypt.HashPassword(restaurant.Password), Location = restaurant.Location, ListString = restaurant.ListString, SocialMedia = restaurant.SocialMedia };

            if (restaurants == null)
            {
                _context.Restaurant.Add(res1);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("ErrorExsistingUser");

            return CreatedAtAction("GetRestaurant", new { id = res1.Id }, res1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurant.Any(e => e.Id == id);
        }
    }
}
