using Events.Domain;

namespace Events.API.ViewModels
{
    public class EventsViewModel
    {
        public Event Events { get; set; }
        public Person Person { get; set; }
        public Company Company { get; set; }    
        public IEnumerable<EventPerson> EventPersons { get; set; }
        public IEnumerable<EventCompany> EventCompanies { get; set; }   
    }
}
