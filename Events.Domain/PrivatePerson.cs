
namespace Events.Domain
{
    public class PrivatePerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Participant? Participant { get; set; }
    }
}
