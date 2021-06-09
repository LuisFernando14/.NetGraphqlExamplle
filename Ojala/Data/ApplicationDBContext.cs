using Microsoft.EntityFrameworkCore;
using Ojala.Models;

namespace Ojala.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {

        }
        public DbSet<Dog> Dog { get; set; }
    }
}
