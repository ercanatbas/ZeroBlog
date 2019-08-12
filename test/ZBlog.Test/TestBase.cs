using NUnit.Framework;
using System;

namespace ZBlog.Test
{
    [SetUpFixture]
    public class TestBase
    {
        protected virtual void BeginTest()
        {
            Console.WriteLine("TestStarting");
        }

        [OneTimeSetUp]
        protected virtual void RunBeforeAnyTests()
        {
            Console.WriteLine("BeforeTest");
        }
        [OneTimeTearDown]
        protected virtual void RunAfterAnyTests()
        {
            Console.WriteLine("AfterTest");
        }
        [SetUp]
        protected virtual void SetUp()
        {

        }
    }
}
