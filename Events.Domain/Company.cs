
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Domain
{
    public class Company
    {
        public int CompanyId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Ettevõtte nimi:")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Registrikood:")]
        public long RegistryCode { get; set; }
        [Display(Name = "Lisainfo:")]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [NotMapped]
        public int EventID { get; set; }
        public ICollection<EventCompany>? EventCompanies { get; set; }
    }
}
