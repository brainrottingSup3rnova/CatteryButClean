using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public sealed class TINTest
    {
        [TestMethod]
        public void TIN_NumberIsShorter_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new TIN("1234567"));
        }
    }
}
