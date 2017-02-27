using AutoMapper;
using Business.Interfaces;
using Common.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using Moq;

namespace BusinessBenutzerServiceTest
{

    [TestFixture]
    public class BenutzerGruppenViewModelTest
    {
        public IBenutzerRepository MockBenutzerRepository { get; set; }
        public IBenutzerGruppeService MockBenutzerGruppeService { get; set; }
        public IMailService MockMailService { get; set; }
        public IMd5Hash MockMD5Hash { get; set; }
        private IMapper MockMapper { get; set; }
        private Fixture Fixture { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void BenutzerServiceTest()
        {
            //Assert
            var benutzerGruppe = Fixture.Build<BenutzerGruppe>().Create();
            var createBenutzerGruppeViewModel = Fixture.Build<CreateBenutzerGruppeViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<BenutzerGruppe>(It.IsAny<CreateBenutzerGruppeViewModel>())).Returns(benutzerGruppe);
            MockMapper = mockMapper.Object;

            var benutzerGruppenViewModelService = new BenutzerGruppeViewModelService();

            //Act
            var result = benutzerGruppenViewModelService.Map_CreateBenutzerGruppeViewModel_BenutzerGruppe(createBenutzerGruppeViewModel);

            //Assert 

            Assert.AreEqual(benutzerGruppe.GetType(), result.GetType());
        }

        [Test]
        public void SearchUserByIdTest()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var id = benutzer.BenutzerId;
            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(r => r.SearchUserById<>(It.IsAny<Benutzer>())).Returns(benutzer);
            mockBenutzerRepository = mockBenutzerRepository.Object;

        }

        [Test]
        public void SearchUserByIdNoTrackingTest()
        {

        }

        [Test]
        public void SearchUserByEmailTest()
        {

        }

        [TestMethod()]
        public void FindAllBenutzersTest()
        {

        }

        [TestMethod()]
        public void FindAllMitarbeiterWithPagingTest()
        {

        }

        [TestMethod()]
        public void AddBenutzerTest()
        {

        }

        [TestMethod()]
        public void AddMitarbeiterTest()
        {

        }

        [TestMethod()]
        public void RegisterBenutzerTest()
        {

        }

        [TestMethod()]
        public void ForgottenPasswordEmailForBenutzerTest()
        {

        }

        [TestMethod()]
        public void EditBenutzerTest()
        {

        }

        [TestMethod()]
        public void RemoveBenutzerTest()
        {

        }

        [TestMethod()]
        public void CheckEmailForRegistrationTest()
        {

        }

        [TestMethod()]
        public void VerifyRegistrationTest()
        {

        }

        [TestMethod()]
        public void VerifyPasswordChangeTest()
        {

        }

        [TestMethod()]
        public void EditBenutzerPasswordTest()
        {

        }

        [TestMethod()]
        public void GetMitarbeiterCountTest()
        {

        }
    }
}