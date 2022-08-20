using Microsoft.EntityFrameworkCore;
using Events.Domain;

namespace Events.API.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<PrivatePerson> PrivatePeople => Set<PrivatePerson>();
        public DbSet<Company> Companies => Set<Company>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(p => p.PrivatePeople)
                .WithMany(p => p.Events)
                .UsingEntity<EventPrivatePerson>(
                    j => j
                        .HasOne(pt => pt.PrivatePerson)
                        .WithMany(t => t.EventPrivatePeople)
                        .HasForeignKey(pt => pt.PrivatePersonId),
                    j => j
                        .HasOne(pt => pt.Event)
                        .WithMany(p => p.EventPrivatePeople)
                        .HasForeignKey(pt => pt.EventId),
                    j =>
                    {
                        j.HasKey(t => new { t.EventId, t.PrivatePersonId });
                    });

            modelBuilder.Entity<Event>()
                  .HasMany(p => p.Companies)
                  .WithMany(p => p.Events)
                  .UsingEntity<EventCompany>(
                      j => j
                          .HasOne(pt => pt.Company)
                          .WithMany(t => t.EventCompanies)
                          .HasForeignKey(pt => pt.CompanyId),
                      j => j
                          .HasOne(pt => pt.Event)
                          .WithMany(p => p.EventCompanies)
                          .HasForeignKey(pt => pt.EventId),
                      j =>
                      {
                          j.HasKey(t => new { t.EventId, t.CompanyId });
                      });
        }
    }
}
