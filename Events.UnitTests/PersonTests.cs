using Events.Domain;
using Xunit;

namespace Events.UnitTests
{
    public class PersonTests
    {
        [Fact]
        public void CanAddPerson()
        {
            var p = new Person
            {
                FirstName = "Andres",
                LastName = "Rebane",
                PersonalCode = 37507090173
            };

            Assert.NotNull(p);
        }

        [Fact]
        public void CanChangePerson()
        {
            var p = new Person
            {
                FirstName = "Andres",
                LastName = "Rebane",
                PersonalCode = 37507090173
            };

            p.FirstName = "Mati";
            p.LastName = "Karu";
            p.PersonalCode = 38002123429;

            Assert.Equal("Mati", p.FirstName);
            Assert.Equal("Karu", p.LastName);
            Assert.Equal(38002123429, p.PersonalCode);
        }

    }
}
