
namespace Events.Domain
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }
        public List<EventCompany>? EventCompanies { get; set; }
    }
}
