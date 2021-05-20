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
        private string[] names = { "Anna", "Vardan", "John", "Lily", "Suren" };

        private string[] surNames = { "Karapetyan", "Vardanyan", "Smith", "Babayan", "Kazazyan" };

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
        //[HttpGet]
        //public IEnumerable<User> Get()
        //{

        //    Random rnd = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new User
        //    {
        //        ID = index,
        //        SureName = names[rnd.Next(0, 5)],
        //        LastName = surNames[rnd.Next(0, 5)],
        //        Age = rnd.Next(10, 60),
        //        Salary = rnd.Next(1, 100) * 10000,

        //    })
        //    .ToArray();

        //}
    }
}
