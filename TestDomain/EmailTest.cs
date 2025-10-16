using Domain.Model.ValueObjects;
using Domain.Model.Entities;

namespace TestDomain
{
    [TestClass]
    public sealed class EmailTest
    {
        [TestMethod]
        public void Email_DoesntContainPeriod_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Email("example@domaincom"));
        }

        [TestMethod]
        public void Email_DoesntContainAtSign_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Email("exampledomain.com"));
        }
    }
}
