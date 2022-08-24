
using System;

using System.ComponentModel.DataAnnotations;

namespace Events.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Ürituse nimi:")]
        public string EventTitle { get; set; } = string.Empty;
        [Display(Name = "Lisainfo:")]
        [StringLength(1000, MinimumLength = 3)]
        public string EventDescription { get; set; } = string.Empty;
        [Display(Name = "Koht:")]
        public string EventVenue { get; set; } = string.Empty;

        [Display(Name = "Toimumisaeg:")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        
        public ICollection<EventPerson>? EventPersons { get; set; }
        public ICollection<EventCompany>? EventCompanies { get; set; }
    }
}
