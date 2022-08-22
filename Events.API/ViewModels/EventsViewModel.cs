using Events.Domain;

namespace Events.API.ViewModels
{
    public class EventsViewModel
    {
        public Event Event { get; set; }
        public Person Person { get; set; }
    }
}
