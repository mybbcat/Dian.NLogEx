using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading;
using Dian.NLogEx;
using NUnit.Framework;


namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            NormalLogger.Fatal(GetType(), "This is a {0} log text!", new Exception(),"fatal");
            NormalLogger.Fatal(GetType(), "This is a  log text!");
            Assert.IsTrue(true);
        }

        [Test]
        public void TestAsync()
        {
            var i = 1;
            while (i <= 2000)
            {
                NormalLogger.Trace(GetType(),"#{0} log text!", i);
                i++;
                Thread.Sleep(100);
            }
            Assert.IsTrue(true);
        }
    }
}
