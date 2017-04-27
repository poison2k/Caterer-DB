using System.Collections.Generic;
using System.Linq;
using Business.Services;
using DataAccess.Interfaces;
using DataAccess.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using MockData;

namespace Business.Test.Business
{
    public class BenutzerGruppeServiceTest
    {
     
        [TestFixture]
        public class RechteGruppeServiceTests
        {
            public IBenutzerGruppeRepository MockBenutzerGruppeRepository { get; set; }
            private Fixture Fixture { get; set; }
            private BenutzerGruppeService BenutzerGruppeService { get; set; }

            [OneTimeSetUp]
            public void TestInit()
            {
                Fixture = new Fixture();
                Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
                Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

                var mockBenutzerGruppeRepository = new Mock<IBenutzerGruppeRepository>();
                mockBenutzerGruppeRepository.Setup(x => x.SearchGroup()).Returns(MockBenutzerGruppeModel.ListeBenutzerGruppe);
                mockBenutzerGruppeRepository.Setup(x => x.SearchGroupById(It.IsAny<int>())).Returns(MockBenutzerGruppeModel.AdminBenutzerGruppe);
                mockBenutzerGruppeRepository.Setup(x => x.SearchGroupByBezeichnung(It.IsAny<string>())).Returns(MockBenutzerGruppeModel.AdminBenutzerGruppe);
                MockBenutzerGruppeRepository = mockBenutzerGruppeRepository.Object;

                BenutzerGruppeService = new BenutzerGruppeService(MockBenutzerGruppeRepository);
            }
        

            [Test]
            public void FindAllGroups_Test()
            {
                //Arrange

                //Act
                var result = BenutzerGruppeService.FindAllGroups();

                //Assert
                Assert.IsNotNull(result);
                Assert.IsNotEmpty(result);
            }

            [Test]
            public void SearchGroupById_Test()
            {
                //Arrange

                //Act
                var result = BenutzerGruppeService.SearchGroupById(1);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.NutzerGruppeID);
            }

            [Test]
            public void SearchGroupByBezeichnung()
            {
                //Arrange

                //Act
                var result = BenutzerGruppeService.SearchGroupByBezeichnung("Administrator");

                Assert.IsNotNull(result);
                Assert.AreEqual("Administrator", result.Bezeichnung);
            }
        }
    }
}