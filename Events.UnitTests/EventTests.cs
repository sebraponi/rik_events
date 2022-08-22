using Events.Domain;
using Xunit;

namespace Events.UnitTests
{
    public class EventTests
    {
        [Fact]
        public void CanAddEvent()
        {
            var p = new Event
            {
                EventTitle = "Rakvere Suvi",
                EventVenue = "Rakvere",
                Date = DateTime.Now,
            };

            Assert.NotNull(p);
        }

        [Fact]
        public void CanChangeEvent()
        {
            var p = new Event
            {
                EventTitle = "Rakvere Suvi",
                EventVenue = "Rakvere",
                Date = DateTime.Now,
            };

            p.EventVenue = "Kunda";

            Assert.Equal("Kunda", p.EventVenue);
        }

        [Fact]
        public void CanAddParticiPant()
        {
            var p = new Event
            {
                EventId = 1,
                EventTitle = "Rakvere Suvi",
                EventVenue = "Rakvere",
                Date = DateTime.Now,
                EventDescription = "Suvi Rakveres"
            };

            var e = new Person
            {
                PersonId = 11,
                FirstName = "Katri",
                LastName = "Mutri"
            };

            var c = new Company
            {
                CompanyId = 12,
                Name = "Kalamaja Puhvet"
            };

            var ep = new EventPerson
            {
                EventId = p.EventId,
                PersonId = e.PersonId
            };

            var ec = new EventCompany
            {
                EventId = p.EventId,
                CompanyId = c.CompanyId
            };

            Assert.Equal(ep.EventId, p.EventId);
            Assert.Equal(ep.PersonId, e.PersonId);
            Assert.Equal(ec.CompanyId, c.CompanyId);
        }
    }
}
