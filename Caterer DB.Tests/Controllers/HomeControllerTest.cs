using Caterer_DB.Controllers;
using Caterer_DB.Interfaces;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using System.Web.Mvc;

namespace Caterer_DB.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private Fixture Fixture { get; set; }

        private IBenutzerViewModelService MockBenutzerViewModelService { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void Index()
        {
            //Arrange

            MockBenutzerViewModelService = new Mock<IBenutzerViewModelService>().Object;

            var controller = new HomeController(MockBenutzerViewModelService);
            FakeHttpContext.SetFakeContext(controller, true);
            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Contact()
        {
            //Arrange
            MockBenutzerViewModelService = new Mock<IBenutzerViewModelService>().Object;

            var controller = new HomeController(MockBenutzerViewModelService);

            //Act
            ViewResult result = controller.Contact() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Datenschutz()
        {
            //Arrange
            MockBenutzerViewModelService = new Mock<IBenutzerViewModelService>().Object;

            var controller = new HomeController(MockBenutzerViewModelService);

            //Act
            ViewResult result = controller.Datenschutz() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AGB()
        {
            //Arrange
            MockBenutzerViewModelService = new Mock<IBenutzerViewModelService>().Object;

            var controller = new HomeController(MockBenutzerViewModelService);

            //Act
            ViewResult result = controller.AGB() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            //Arrange
            MockBenutzerViewModelService = new Mock<IBenutzerViewModelService>().Object;

            var controller = new HomeController(MockBenutzerViewModelService);

            //Act
            ViewResult result = controller.Contact() as ViewResult;

            //Assert
            Assert.AreEqual("Ihre Kontakt Seite", result.ViewBag.Message);
        }
    }
}