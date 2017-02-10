using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caterer_DB;
using Caterer_DB.Controllers;
using UnityAutoMoq;
using Ploeh.AutoFixture;
using Caterer_DB.Models;
using Caterer_DB.Interfaces;
using Microsoft.Practices.Unity;

namespace Caterer_DB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : TestBase
    {

        private Fixture Fixture { get; set; }

        protected override UnityAutoMoqContainer RegisterTypes(UnityAutoMoqContainer container)
        {
            container.RegisterType<HomeController>(new TransientLifetimeManager());

            return container;
        }

        protected override UserModel AktuellerNutzer
        {
            get { return new UserModel("sebastianbuenck", 111111, Container.Resolve<ILoginService>()); }
        }

        [TestInitialize]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = Container.Resolve<HomeController>();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Account()
        {
            // Arrange
            var controller = Container.Resolve<HomeController>();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var controller = Container.Resolve<HomeController>();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Datenschutz()
        {
            // Arrange
            var controller = Container.Resolve<HomeController>();

            // Act
            ViewResult result = controller.Datenschutz() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AGB()
        {
            // Arrange
            var controller = Container.Resolve<HomeController>();

            // Act
            ViewResult result = controller.AGB() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            var controller = Container.Resolve<HomeController>();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
