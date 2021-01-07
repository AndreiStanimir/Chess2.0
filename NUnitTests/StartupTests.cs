using Chess20;
using Chess20.Controllers;
using Chess20.Factories;
using Chess20.Models;
using Moq;
using NUnit.Framework;
using Owin;
using System.Web.Mvc;
using Chess20.Models.Entities;

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

        public void CreateAdminAndUserRoles_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var startup = this.CreateStartup();

            // Act
            //startup.CreateAdminAndUserRoles();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        //[Test]
        public void GetGameFromGameController()
        {
            GamesController controller = new GamesController();
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void DoesChangingGamemodeModifyTimesProperly()
        {
            const int timeBullet = 60;
            const int incrementBullet = 1;
            Gamemode gamemodeBullet = new Gamemode
            {
                GamemodeId = 1,
                Name = "Bullet",
                Increment = incrementBullet,
                Time = timeBullet
            };
            const int timeBlitz = 180;
            const int incrementBlitz = 2;

            Gamemode gamemodeBlitz = new Gamemode
            {
                GamemodeId = 1,
                Name = "Blitz",
                Increment = incrementBlitz,
                Time = timeBlitz
            };
            Game game = new Game()
            {
                Gamemode = gamemodeBullet,
                GameId = 0,
                Moves = "sfd",
                Player1 = UserFactory.GetAdmin(),
                Player2 = UserFactory.GetPlayer()
            };
            Assert.AreEqual(incrementBullet, game.Gamemode.Increment);
            Assert.AreEqual(timeBullet, game.Timer1.TotalSeconds);

            game.Gamemode = gamemodeBlitz;
            Assert.AreEqual(timeBlitz, game.Timer1.TotalSeconds);
        }
    }
}