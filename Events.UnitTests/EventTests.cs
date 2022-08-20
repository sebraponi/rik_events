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

            var e = new PrivatePerson
            {
                PrivatePersonId = 11,
                FirstName = "Katri",
                LastName = "Mutri"
            };

            var c = new Company
            {
                CompanyId = 12,
                Name = "Kalamaja Puhvet"
            };

            var ep = new EventPrivatePerson
            {
                EventId = p.EventId,
                PrivatePersonId = e.PrivatePersonId
            };

            var ec = new EventCompany
            {
                EventId = p.EventId,
                CompanyId = c.CompanyId
            };

            Assert.Equal(ep.EventId, p.EventId);
            Assert.Equal(ep.PrivatePersonId, e.PrivatePersonId);
            Assert.Equal(ec.CompanyId, c.CompanyId);
        }
    }
}
