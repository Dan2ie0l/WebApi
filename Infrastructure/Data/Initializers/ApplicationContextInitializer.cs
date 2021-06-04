using RestApi.Domain.Core;
using RestApi.Implementations.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Initializers
{
    public class ApplicationContextInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext applicationContext)
        {
            await applicationContext.Database.EnsureCreatedAsync();

            if (!applicationContext.Restaurant.Any())
            {
                IEnumerable<Restaurant> languages = new List<Restaurant>
                {
                    new Restaurant { Name = "Restaurant 1", Description = "Description 1", Phone1 = "+37491919191", Website = "www.google.com" },
                    new Restaurant { Name = "Restaurant 2", Description = "Description 2", Phone1 = "+37477777777", Website = "www.yandex.ru" },
                    new Restaurant { Name = "Restaurant 3", Description = "Description 3", Phone1 = "+37499555555", Website = "www.bing.com" }

                };

                await applicationContext.Restaurant.AddRangeAsync(languages);
                await applicationContext.SaveChangesAsync();
            }
        }
    }
}
