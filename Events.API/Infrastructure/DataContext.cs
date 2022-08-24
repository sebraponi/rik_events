using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Events.Domain;


namespace Events.API.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<EventPerson> PublicPeople => Set<EventPerson>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<EventCompany> EventsCompanies => Set<EventCompany>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<EventPerson>().ToTable("EventPerson");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<EventCompany>().ToTable("EventCompany");

            modelBuilder.Entity<EventCompany>()
                .HasKey(c => new { c.EventId, c.CompanyId });

            modelBuilder.Entity<EventPerson>()
                .HasKey(p => new { p.EventId, p.PersonId });
        }
    }
}
