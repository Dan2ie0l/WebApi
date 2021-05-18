using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private string[] names = { "Anna", "Vardan", "John", "Lily", "Suren" };

        private string[] surNames = { "Karapetyan", "Vardanyan", "Smith", "Babayan", "Kazazyan" };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            
            Random rnd = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
            {
                ID = index,
                SureName = names[rnd.Next(0, 5)],
                LastName = surNames[rnd.Next(0, 5)],
                Age = rnd.Next(10, 60),
                Salary = rnd.Next(1, 100) * 10000,
                
            })
            .ToArray();
            
        }
    }
}
