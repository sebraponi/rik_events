using System.ComponentModel.DataAnnotations;

namespace Events.ViewModels
{
    public partial class PersonsView
    {
        public int PersonId { get; set; }
        [Display(Name = "Eesnimi:")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Eesnimel peab olema suur algustäht!")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Perenimi:")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Perenimel peab olema suur algustäht!")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Isikukood:")]
        public long PersonalCode { get; set; }
        [Display(Name = "Maksmisviis:")]
        public string PaymentType { get; set; } = string.Empty;
        [Display(Name = "Lisainfo:")]
        public string Description { get; set; } = string.Empty;

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
