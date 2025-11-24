using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TomekReads.Server.Data.Services;

namespace TomekReads.Server.Test
{
    [TestFixture]
    public class TestServiceShould
    {
        TestService ts;
        String name;

        [SetUp]
        public void Init()
        {
            ts = new TestService();
            ts.Arm = "test";
            name = "testname";
        }

        [TearDown]
        public void End()
        {
            ts.Arm = "";
            name = "";
        }
        [TestCase("test")]
        public void GetArmShould(string testArm)
        {
            var arm = ts.getArm("test");
            Assert.That(testArm, Is.EqualTo(arm));
        }
    }
}
