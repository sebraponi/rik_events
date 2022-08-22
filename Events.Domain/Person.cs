
namespace Events.Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }
        public List<EventPerson>? EventPersons { get; set; }
    }
}
