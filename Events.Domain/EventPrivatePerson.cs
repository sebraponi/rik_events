
namespace Events.Domain
{
    public class EventPrivatePerson
    {
        public int EventId { get; set; }
        public Event? Event { get; set; }

        public int PrivatePersonId { get; set; }
        public PrivatePerson? PrivatePerson { get; set; }
    }
}
