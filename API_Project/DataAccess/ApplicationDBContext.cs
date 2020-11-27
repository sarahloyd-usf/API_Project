using Microsoft.EntityFrameworkCore;
using API_Project.Models;

namespace API_Project.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<CovidData> CovidData { get; set; }
        public DbSet<State> States { get; set; }
    }
}