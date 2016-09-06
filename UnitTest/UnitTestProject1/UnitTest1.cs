using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading;
using Dian.NLogEx;
using Newtonsoft.Json.Bson;
using NUnit.Framework;


namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Logger.Fatal(GetType(), "This is a {0} log text!", new Exception(),"fatal");
            Logger.Trace(GetType(), "This is a  log text!");
            Assert.IsTrue(true);
        }

        [Test]
        public void TestAsync()
        {
            var i = 1;
            while (i <= 2000)
            {
                Logger.Trace(GetType(),"#{0} log text!", i);
                i++;
                Thread.Sleep(100);
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void TestWebVisitToELK()
        {
//            UserVisitLogger.Output("127.0.0.1","Url","Parameter","Body",100,200,"测试平台");
            UserVisitLogger.Output("127.0.0.1", "Url", "Parameter", "Body", 100, 200, "测试平台","message");
            UserVisitLogger.Output("127.0.0.1", "Url", "Parameter", "Body", 100, 200, "测试平台", "message-{0}","you");
        }
    }
}
