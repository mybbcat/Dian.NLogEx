using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
            NormalLogger.Info("This is a unit test log text!");
            NormalLogger.Info("This is a unit test log text{0}!","ddddd");
            NormalLogger.Error(new FileNotFoundException());
            Assert.IsTrue(true);
        }
    }
}
