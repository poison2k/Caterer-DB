using Ploeh.AutoFixture;
using Caterer_DB.Controllers;
using System.Linq;
using System.Web.Mvc;
using Caterer_DB.Models;
using Caterer_DB.Interfaces;
using Caterer_DB.Services;
using Business.Interfaces;
using Moq;
using DataAccess.Model;
using NUnit.Framework;

namespace Caterer_DB.Tests.Controllers
{

    [TestFixture]
    public class AccountControllerTest
    { 
        
        private Fixture Fixture { get; set; }

        private IBenutzerViewModelService MockBenutzerViewModelService { get; set; }
        private ILoginService MockLoginService { get; set; }
        private IBenutzerService MockBenutzerService { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            MockBenutzerViewModelService = new Mock<IBenutzerViewModelService>().Object;
            MockLoginService = new Mock<ILoginService>().Object;
            MockBenutzerService = new Mock<IBenutzerService>().Object;
        }

        [Test]
        public void Login_HTTPGet_Test()
        {
            //Arrange
            var controller = new AccountController(MockLoginService ,MockBenutzerService, MockBenutzerViewModelService);
            
            //Act
            ActionResult result = controller.Login(null);

            //Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public void LoginVorgang_ErfolgriechVerifiziertTest()
        {

            //Arrange
            var benutzer = Fixture.Build<Benutzer>().WithAutoProperties().Create();
            benutzer.IstEmailVerifiziert = true;

            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(x => x.AnmeldePrüfung(It.IsAny<string>(), It.IsAny<string>())).Returns(LoginSuccessLevel.Erfolgreich);
            MockLoginService = mockLoginService.Object;

            var mockBenutzerService = new Mock<IBenutzerService>();
            mockBenutzerService.Setup(x => x.SearchUserByEmail(It.IsAny<string>())).Returns(benutzer);
            MockBenutzerService = mockBenutzerService.Object;

            var accountController = new AccountController(MockLoginService, MockBenutzerService, MockBenutzerViewModelService);
            FakeHttpContext.SetFakeContext(accountController,true);

            //Act
            ActionResult result = accountController.Login(Fixture.Build<LoginModel>().Create(), "Home/Index");
            string routeController = ((RedirectToRouteResult)result).RouteValues["Controller"].ToString();
            string routeAction = ((RedirectToRouteResult)result).RouteValues["Action"].ToString();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", routeController);
            Assert.AreEqual("Index", routeAction);

        }

        [Test]
        public void RegisterVorgang_Test()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
