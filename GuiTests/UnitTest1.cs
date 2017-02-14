using Caterer_DB.Controllers;
using Moq;
using NUnit.Framework;
using Caterer_DB.Interfaces;
using Ploeh.AutoFixture;
using Caterer_DB.Models;
using System.Web.Mvc;
using UnityAutoMoq;
using Microsoft.Practices.Unity;
using System.Web;
using System.Security.Principal;
using System.Web.Routing;
using System;
using System.Collections.Specialized;

namespace GuiTests
{
    [TestFixture]
    public class UnitTest1
    {

        private Fixture Fixture { get; set; }

        //private bool registered;

        //protected UnityAutoMoqContainer Container { get; private set; }

        

        [OneTimeSetUp]
        public void SetUp()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

      
        [Test]
        public void TestIndex()
        {
            HttpContextManager.SetCurrentContext(GetMockedHttpContext());
            var controllerContext = new Mock<ControllerContext>();
            var principal = new Mock<IPrincipal>();
            var baseController = new Mock<BaseController>();
           
            principal.Setup(p => p.IsInRole("Administrator")).Returns(true);
            principal.Setup(p => p.Identity.IsAuthenticated).Returns(true);
            principal.SetupGet(x => x.Identity.Name).Returns("userName");
            controllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            

            var test = Fixture.Build<RegisterBenutzerViewModel>().WithAutoProperties().Create();
            var mockBenutzerViewModelService = new Mock<IBenutzerViewModelService>();
            mockBenutzerViewModelService.Setup(x => x.CreateNewRegisterBenutzerViewModel()).Returns(test);

          

            HomeController homecontroller = new HomeController(mockBenutzerViewModelService.Object);
            homecontroller.ControllerContext = controllerContext.Object;

            //Act            
            var result = homecontroller.Index() as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "Index");
        }


        public class HttpContextManager
        {
            private static HttpContextBase m_context;
            public static HttpContextBase Current
            {
                get
                {
                    if (m_context != null)
                        return m_context;

                    if (HttpContext.Current == null)
                        throw new InvalidOperationException("HttpContext not available");

                    return new HttpContextWrapper(HttpContext.Current);
                }
            }

            public static void SetCurrentContext(HttpContextBase context)
            {
                m_context = context;
            }
        }


        private HttpContextBase GetMockedHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();
            var urlHelper = new Mock<UrlHelper>();

            var routes = new RouteCollection();
            var requestContext = new Mock<RequestContext>();
            requestContext.Setup(x => x.HttpContext).Returns(context.Object);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);
            user.Setup(ctx => ctx.Identity).Returns(identity.Object);
            identity.Setup(id => id.IsAuthenticated).Returns(true);
            identity.Setup(id => id.Name).Returns("test");
            request.Setup(req => req.Url).Returns(new Uri("http://www.google.com"));
            request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            request.SetupGet(req => req.Headers).Returns(new NameValueCollection());

            return context.Object;
        }

    }
}
