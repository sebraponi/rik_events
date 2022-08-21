
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Events.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        [StringLength(1000)]
        public string EventDescription { get; set; } = string.Empty;
        public string EventVenue { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        public ICollection<PrivatePerson>? PrivatePeople { get; set; }
        public List<EventPrivatePerson>? EventPrivatePeople { get; set; }
        public ICollection<Company>? Companies { get; set; }
        public List<EventCompany>? EventCompanies { get; set; }
    }
}
