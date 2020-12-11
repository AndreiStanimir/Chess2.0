using Chess20;
using Moq;
using NUnit.Framework;
using Owin;
using System;

using Chess20;

using Chess20.Controllers;

using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NUnitTests
{
    [TestFixture]
    public class StartupTests
    {
        private MockRepository mockRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Startup CreateStartup()
        {
            return new Startup();
        }

        [Test]
        public void Configuration_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var startup = new Startup();
            IAppBuilder app = null;

            // Act
            startup.Configuration(app);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void CreateAdminAndUserRoles_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var startup = this.CreateStartup();

            // Act
            startup.CreateAdminAndUserRoles();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}