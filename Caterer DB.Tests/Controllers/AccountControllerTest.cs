
//using Microsoft.Practices.Unity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Ploeh.AutoFixture;
//using Caterer_DB.Controllers;
//using System.Linq;
//using System.Web.Mvc;
//using UnityAutoMoq;
//using DataAccess.Model;
//using System.Web;
//using System.IO;
//using System.Security.Principal;
//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;
//using Caterer_DB.Models;

//namespace Caterer_DB.Tests.Controllers
//{
//    [TestClass]
//    public class AccountControllerTest : TestBase
//    {
//        private Fixture Fixture { get; set; }

//        protected override ApplicationUser AktuellerNutzer
//        {
//            get
//            {
//                return new ApplicationUser()
//                {

//                };
//            }
//        }

//        protected override UnityAutoMoqContainer RegisterTypes(UnityAutoMoqContainer container)
//        {
//            container.RegisterType<AccountController>(new TransientLifetimeManager());

//            return container;
//        }

//        [TestInitialize]
//        public void TestInit()
//        {
//            Fixture = new Fixture();
//            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
//            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
//        }


//        [TestMethod]
//        public void LoginURLTest()
//        {

//            // Arrange
//            AccountController controller = new AccountController();

//            // Act
//            ViewResult result = controller.Login(null) as ViewResult;

//            // Assert
//            Assert.IsNotNull(result);

//        }

//        [TestMethod]
//        public void LoginVorgangTest()

//        {

//            //Arrange
//            HttpContext.Current = CreateHttpContext(userLoggedIn: false);
//            var accountController = Container.Resolve<AccountController>();
//            var userStore = new Mock<IUserStore<ApplicationUser>>();
//            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
//            var authenticationManager = new Mock<IAuthenticationManager>();
//            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

//            //Act
//            var result = accountController.Login(Fixture.Build<UserModel>().Create(), "Start#22");
//            string ViewName = ((ViewResult)result).ViewName;


//            //Assert
//            Assert.IsNotNull(result);
           
//        }





//        private static HttpContext CreateHttpContext(bool userLoggedIn)
//        {
//            var httpContext = new HttpContext(
//                new HttpRequest(string.Empty, "http://sample.com", string.Empty),
//                new HttpResponse(new StringWriter())
//            )
//            {
//                User = userLoggedIn
//                    ? new GenericPrincipal(new GenericIdentity("userName"), new string[0])
//                    : new GenericPrincipal(new GenericIdentity(string.Empty), new string[0])
//            };

//            return httpContext;
//        }
//    }
//}
