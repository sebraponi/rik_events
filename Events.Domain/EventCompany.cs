

namespace Events.Domain
{
    public class EventCompany
    {
        public int CompanyId { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public Company? Company { get; set; }
    }
}
