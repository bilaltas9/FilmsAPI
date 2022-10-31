using Films.Entities.Concreate;
using Microsoft.EntityFrameworkCore;

namespace Films.Business.DataAccess.Context
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECT") ?? throw new Exception("DB Connect Can not found"));
            }
        }
    }
}
