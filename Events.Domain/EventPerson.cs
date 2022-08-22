
namespace Events.Domain
{
    public class EventPerson
    {
        public int EventId { get; set; }
        public Event? Event { get; set; }

        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
