using Events.Domain;
using Xunit;

namespace Events.UnitTests
{
    public class PaymentTests
    {
        [Fact]
        public void CanAddPayment()
        {
            var p = new Payment
            {
                PaymentId = 1,
                PaymentType = "Sularahas"
            };

            Assert.NotNull(p);
        }

        [Fact]
        public void CanChangePayment()
        {
            var p = new Payment
            {
                PaymentId = 23,
                PaymentType = "Kaardimakse"
            };

            p.PaymentType = "Natuuras";
            Assert.Equal("Natuuras", p.PaymentType);
        }

    }
}
