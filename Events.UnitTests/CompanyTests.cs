using Events.Domain;
using Xunit;

namespace Events.UnitTests
{
    public class CompanyTests
    {
        [Fact]
        public void CanAddCompany()
        {
            var c = new Company { Name = "Eesti Rahvusraamatukogu", RegistryCode = 74000139 };

            Assert.NotNull(c);
        }

        [Fact]
        public void CanChangeCompany()
        {
            var c = new Company { Name = "Eesti Rahvusraamatukogu", RegistryCode = 74000139 };

            c.RegistryCode = 88389201;

            Assert.Equal(88389201, c.RegistryCode);

        }

    }
}
