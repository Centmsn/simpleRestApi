using kurs.Entities;
using System.Collections.Generic;
using System.Linq;

namespace kurs
{
    public class ApiSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public ApiSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();

                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<Restaurant>GetRestaurants()
        {
            var restaurants = new List<Restaurant>() {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "example description",
                    ContactEmail = "t@t.com",
                    HasDeliver = true,
                    Dishes = new List<Dish>() {
                        new Dish()
                        {
                            Name = "Burger",
                            Price = 10.3M
                        },
                        new Dish()
                        {
                            Name = "kaczka",
                            Price = 25.60M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Prudnik",
                        Street = "Kościuszki",
                        PostalCode = "48-200"
                    }
            },
                 new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "example description of McDonald",
                    ContactEmail = "t@t.com",
                    HasDeliver = true,
                    Dishes = new List<Dish>() {
                        new Dish()
                        {
                            Name = "Burger",
                            Price = 5.3M
                        },
                        new Dish()
                        {
                            Name = "stripsy",
                            Price = 12.5m
                        }
                    },
                    Address = new Address()
                    {
                        City = "Prudnik",
                        Street = "Dąbrowskiego",
                        PostalCode = "48-200"
                    }
                 }
            };

            return restaurants;
        }

    }
}
