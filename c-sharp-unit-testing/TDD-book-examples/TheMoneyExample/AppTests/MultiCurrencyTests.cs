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
        public void TestDollarMultiplication()
        {
            var five = Money.MakeDollar(5);

            Assert.AreEqual(Money.MakeDollar(10), five.times(2));
            Assert.AreEqual(Money.MakeDollar(15), five.times(3));
        }
            
        [Test]
        public void TestEquality()
        {
            Assert.True(Money.MakeDollar(5).Equals(Money.MakeDollar(5)));
            Assert.False(Money.MakeDollar(5).Equals(Money.MakeDollar(6)));
            Assert.False(Money.MakeDollar(5).Equals(Money.MakeFranc(5)));
        }

        [Test]
        public void TestFrancMultiplication()
        {
            var five = Money.MakeFranc(5);

            Assert.AreEqual(Money.MakeFranc(10), five.times(2));
            Assert.AreEqual(Money.MakeFranc(15), five.times(3));
        }

        [Test]
        public void TestCurrency()
        {
            Assert.AreEqual("USD", Money.MakeDollar(1).GetCurrency());
            Assert.AreEqual("CHF", Money.MakeFranc(1).GetCurrency());
        }

        [Test]
        public void TestSimpleAddition()
        {
            var five = Money.MakeDollar(5);
            var sum = five.Plus(five);
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");
            Assert.AreEqual(Money.MakeDollar(10), reduced);
        }

        [Test]
        public void TestPlusReturnsSum()
        {
            var five = Money.MakeDollar(5);
            var result = five.Plus(five);
            var sum = (Sum)result;
            Assert.AreEqual(five, sum.Augend);
            Assert.AreEqual(five, sum.Added);
        }

        [Test]
        public void TestReduceSum()
        {
            var sum = new Sum(Money.MakeDollar(3), Money.MakeDollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            Assert.AreEqual(Money.MakeDollar(7), result);
        }

        [Test]
        public void TestReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.MakeDollar(1), "USD");
            Assert.AreEqual(Money.MakeDollar(1), result);
        }

    }
}
