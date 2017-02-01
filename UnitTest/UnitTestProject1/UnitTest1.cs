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
            try
            {
                var l = 0;
                var i = 100 / l;
                Logger.Info(GetType(),i.ToString());
            }
            catch (Exception ex)
            {
                var i = 1;
                while (i <= 20)
                {
                    Logger.Fatal(GetType(), "TestMethod1", ex);
                    i++;
                }
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void TestAsync()
        {
            var i = 1;
            while (i <= 20)
            {
                Logger.Fatal(GetType(),"#{0} log text!", new Exception("DDDD"));
                i++;
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