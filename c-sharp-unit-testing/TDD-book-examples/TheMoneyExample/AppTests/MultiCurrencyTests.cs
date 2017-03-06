using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using App;

namespace AppTests
{
    [TestFixture]
    public class MultiCurrencyTests
    {
        [Test]
        public void TestMultiplication()
        {
            var five = new Dollar(5);
            five.times(2);

            Assert.AreEqual(10, five.amount);
        }
            

    }
}
