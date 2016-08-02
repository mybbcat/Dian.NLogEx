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
            NormalLogger.Info("This is a {0} log text!","info");
            NormalLogger.Trace("This is a {0} log text!", "trace");
            NormalLogger.Debug("This is a {0} log text!", "debug");
            NormalLogger.Error("This is a {0} log text!","error");
            Assert.IsTrue(true);
        }
    }
}
