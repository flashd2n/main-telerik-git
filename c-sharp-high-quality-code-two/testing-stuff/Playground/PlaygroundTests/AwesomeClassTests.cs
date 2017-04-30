using Moq;
using NUnit.Framework;
using Playground;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests
{
    [TestFixture]
    public class AwesomeClassTests
    {
        [Test]
        public void TestingThePublicMethodResult_WhenValidValues()
        {
            var sut = new AwesomeClass();

            var result = sut.SumResult(5, 4);

            Assert.AreEqual(9, result);

        }


    }
}
