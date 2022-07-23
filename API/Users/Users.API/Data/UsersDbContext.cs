using Microsoft.EntityFrameworkCore;
using Users.API.Models;

namespace Users.API.Data
{
    public class UsersDbContext:DbContext
    {
        public UsersDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
