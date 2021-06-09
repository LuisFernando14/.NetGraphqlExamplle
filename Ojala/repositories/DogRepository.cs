using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ojala.Data;
using Ojala.Models;
using System.Linq;

namespace Ojala.repositories
{
    public class DogRepository
    {
        private readonly IServiceProvider serviceProvider;

        public DogRepository(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            // serviceProvider.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>();
        }

        public Task<List<Dog>> Get(int id)
        {
            using var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>());
            var dogs = from m in context.Dog select m;

            return dogs.Where(t => t.Id.Equals(id)).ToListAsync();
        }
    }
}
