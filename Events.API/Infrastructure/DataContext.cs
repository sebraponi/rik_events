using Microsoft.EntityFrameworkCore;
using Events.Domain;

namespace Events.API.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<JuridicalPerson> JuridicalPersons => Set<JuridicalPerson>();
        public DbSet<PrivatePerson> PrivatePersons => Set<PrivatePerson>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(p => p.Participants)
                .WithMany(p => p.Events)
                .UsingEntity<EventParticipant>(
                    j => j
                        .HasOne(pt => pt.Participant)
                        .WithMany(t => t.EventParticipants)
                        .HasForeignKey(pt => pt.ParticipantId),
                    j => j
                        .HasOne(pt => pt.Event)
                        .WithMany(p => p.EventParticipants)
                        .HasForeignKey(pt => pt.EventId),
                    j =>
                    {
                        j.HasKey(t => new { t.EventId, t.ParticipantId });
                    });
        }
    }
}
