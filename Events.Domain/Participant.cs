

namespace Events.Domain
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public ICollection<Event>? Events { get; set; }
        public List<EventParticipant>? EventParticipants { get; set; }
        public List<PrivatePerson>? PrivatePerson { get; set; }
        public List<JuridicalPerson>? juridicalPerson { get; set; }
    }
}
