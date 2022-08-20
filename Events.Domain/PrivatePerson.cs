
namespace Events.Domain
{
    public class PrivatePerson
    {
        public int PrivatePersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }
        public List<EventPrivatePerson>? EventPrivatePeople { get; set; }
    }
}
