using Microsoft.EntityFrameworkCore;
using PruebaTecnicaInfrastucture.Configuration;
using PruebaTecnicaModel.Model;

namespace PruebaTecnicaInfrastucture.context
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext(DbContextOptions<PruebaDbContext> options): base(options) { }

        public DbSet<Students> Students { get; set; }
        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new Personconfiguration());

        }
    }
}
