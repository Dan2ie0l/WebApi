using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Models;

namespace RestApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }


        [HttpGet]
        public IEnumerable<Tables> Get()
        {
            return db.Tables.ToList();
        }

         [HttpGet("{id}")]
        public IEnumerable<User> GetUser(int id)
        {

            Random rnd = new Random();
            return Enumerable.Range(1, id).Select(index => new User
            {
                FirstName = "Levon",
                LastName = "Ayvazyan"
                

            })
            .ToArray();

        }
    }
}
