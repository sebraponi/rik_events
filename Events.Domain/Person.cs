using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        [Display(Name = "Eesnimi:")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Eesnimel peab olema suur algustäht!")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Perenimi:")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Pereimel peab olema suur algustäht!")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Isikukood:")]
        public long PersonalCode { get; set; }
        [Display(Name = "Maksmisviis:")]
        public string PaymentType { get; set; } = string.Empty;
        [Display(Name = "Lisainfo:")]
        [StringLength(1500, MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        public ICollection<EventPerson>? EventPersons { get; set; }

        [NotMapped]
        public int EventID { get; set; }    

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
