using NUnit.Framework;
using System;
using System.IO;


namespace WebApiUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        private WebApiProject.DummyClass _math;
        //SetUp
        //TearDown
        [SetUp]
        public void SetUp()
        {
            _math = new WebApiProject.DummyClass();
        }
        private const string Expected = "Hello World";
        [Test]
        [Ignore("Because I wanted to")]
        public void TestMethod1()
        {

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var result = _math.check();
                //  Assert.AreEqual(Expected, result);
                Assert.That(result, Is.True);
            }
        }
        [Test]
        public void Add_WhenCalled_returnTheSumOfArguments()
        {

            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument( int a, int b , int expectedResult)
        {
            var result = _math.Max(a,b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }


}
