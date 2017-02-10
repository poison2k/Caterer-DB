
using Microsoft.Practices.Unity;
using Moq;
using Ploeh.AutoFixture;
using Caterer_DB.Controllers;
using System.Linq;
using System.Web.Mvc;
using UnityAutoMoq;

using System.Web;
using System.IO;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

using Caterer_DB.Models;
using Caterer_DB.Interfaces;
using Caterer_DB.Services;
using NUnit.Framework;

namespace Caterer_DB.Tests.Controllers
{
   
    [TestFixture]
    public class AccountControllerTest : TestBase
    {
        private Fixture Fixture { get; set; }

        protected override UserModel AktuellerNutzer
        {
            get { return new UserModel("sebastianbuenck", 111111, Container.Resolve<ILoginService>()); }
        }

     

        protected override UnityAutoMoqContainer RegisterTypes(UnityAutoMoqContainer container)
        {
            container.RegisterType<HomeController>(new TransientLifetimeManager());

            return container;
        }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
        
        [Test]
        public void LoginURLTest()
        {

            // Arrange
            var controller = Container.Resolve<AccountController>();


            // Act
            ViewResult result = controller.Login(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public void LoginVorgangTest()

        {

            //Arrange
            var accountController = Container.Resolve<AccountController>();
            Mock<ILoginService> mockAnmeldeService = Container.GetMock<ILoginService>();
            mockAnmeldeService.Setup(x => x.AnmeldePrüfung(It.IsAny<string>(), It.IsAny<string>())).Returns(LoginSuccessLevel.Erfolgreich);

            //Act
            ActionResult result = accountController.Login(Fixture.Build<LoginModel>().Create(), "Home/Index");
            string routeController = ((RedirectToRouteResult)result).RouteValues["Controller"].ToString();
            string routeAction = ((RedirectToRouteResult)result).RouteValues["Action"].ToString();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", routeController);
            Assert.AreEqual("Index", routeAction);

        }
        
        private static HttpContext CreateHttpContext(bool userLoggedIn)
            //Act
        {
            var httpContext = new HttpContext(
                new HttpRequest(string.Empty, "http://sample.com", string.Empty),
                new HttpResponse(new StringWriter())
            )
            
            {
                User = userLoggedIn
                    ? new GenericPrincipal(new GenericIdentity("userName"), new string[0])
                    : new GenericPrincipal(new GenericIdentity(string.Empty), new string[0])
            };
            //Assert
            return httpContext;
        }
    }
}
