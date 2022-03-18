using NUnit.Framework;

namespace PurpleCow.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            // need to setup dependency injection to use the IMapper interface
            // would prefer to create the services layer and then inject the service here, dont want NHibernate dependencies in this project
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}