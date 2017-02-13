﻿using Moq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Caterer_DB.Tests
{
    public static class FakeHttpContext
    {
        public static void SetFakeContext(this Controller controller,bool login)
        {

            var httpContext = MakeFakeContext(login);
            ControllerContext context =
            new ControllerContext(
            new RequestContext(httpContext,
            new RouteData()), controller);
            controller.ControllerContext = context;
        }


        private static HttpContextBase MakeFakeContext(bool login)
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();

            context.Setup(c => c.Request).Returns(request.Object);
            context.Setup(c => c.Response).Returns(response.Object);
            context.Setup(c => c.Session).Returns(session.Object);
            context.Setup(c => c.Server).Returns(server.Object);
            context.Setup(c => c.User).Returns(user.Object);
            user.Setup(c => c.Identity).Returns(identity.Object);
            identity.Setup(i => i.IsAuthenticated).Returns(login);
            identity.Setup(i => i.Name).Returns("admin");

            return context.Object;
        }


    }
}
