
namespace Events.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public string EventVenue { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public ICollection<Participant>? Participants { get; set; }
        public List<EventParticipant>? EventParticipants { get; set; }
    }
}
