using System.Collections.Generic;
using System.Linq;
using Business.Services;
using DataAccess.Interfaces;
using DataAccess.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using MockData;

namespace Business.Test.Business
{
    [TestFixture]
    public class RechteGruppeServiceTests
    {
        public IRechteGruppeRepository MockRechteGruppeRepository { get; set; }
        private Fixture Fixture { get; set; }
        private RechteGruppeService RechteGruppeService { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var rechteGruppeList = new List<RechteGruppe>();
            Fixture.AddManyTo(rechteGruppeList);
            Fixture.RepeatCount = 10;
            Fixture.AddManyTo(rechteGruppeList);

            var mockBenutzerRepository = new Mock<IRechteGruppeRepository>();
            mockBenutzerRepository.Setup(x => x.SearchRightGroup()).Returns(rechteGruppeList);
            mockBenutzerRepository.Setup(x => x.SearchRightGroupById(It.IsAny<int>())).Returns(MockRechteGruppeModel.AdminRechteGruppe());
            MockRechteGruppeRepository = mockBenutzerRepository.Object;

            RechteGruppeService = new RechteGruppeService(MockRechteGruppeRepository);
        }

        [Test]
        public void FindAllRightGroups_Test()
        {
            //Arrange

            //Act
            var result = RechteGruppeService.FindAllRightGroups();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void SearchRightGroupById_Test()
        {
            //Arrange

            //Act
            var result = RechteGruppeService.SearchRightGroupById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.RechteVerwaltungsGruppeId);
        }
    }
}