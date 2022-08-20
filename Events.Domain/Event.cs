
namespace Events.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public string EventVenue { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public ICollection<PrivatePerson>? PrivatePeople { get; set; }
        public List<EventPrivatePerson>? EventPrivatePeople { get; set; }
        public ICollection<Company>? Companies { get; set; }
        public List<EventCompany>? EventCompanies { get; set; }
    }
}
