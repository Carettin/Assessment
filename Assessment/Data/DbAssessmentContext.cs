using Microsoft.EntityFrameworkCore;
using Assessment.Entity;
using Assessment.Data.Configurations;

namespace Assessment.Data
{
    
    public class DbAssessmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbAssessmentContext(DbContextOptions<DbAssessmentContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new InfoConfiguration());


        }

    }
}
