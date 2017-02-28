using AutoMapper;
using Business.Interfaces;
using Common.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using Moq;
using Business.Services;
using System.Collections.Generic;

namespace BusinessBenutzerServiceTest
{

    [TestFixture]
    public class BusinessBenutzerServiceTest
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

            MockMapper = new Mock<IMapper>().Object;
            MockMD5Hash = new Mock<IMd5Hash>().Object;
            MockMailService = new Mock<IMailService>().Object;

        }
             

        [Test]
        public void SearchUserByIdTest()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var id = benutzer.BenutzerId;
            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(r => r.SearchUserById(It.IsAny<int>())).Returns(benutzer);
            MockBenutzerRepository = mockBenutzerRepository.Object;

            var benutzerService = new BenutzerService(MockBenutzerRepository, MockMailService, MockBenutzerGruppeService, MockMD5Hash);

            //Act
            var result = benutzerService.SearchUserById(id);

            //Assert
            Assert.AreEqual(benutzer.GetType(), result.GetType());

        }

        [Test]
        public void SearchUserByIdNoTrackingTest()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var id = benutzer.BenutzerId;
            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(r => r.SearchUserByIdNoTracking(It.IsAny<int>())).Returns(benutzer);
            MockBenutzerRepository = mockBenutzerRepository.Object;

            var benutzerService = new BenutzerService(MockBenutzerRepository, MockMailService, MockBenutzerGruppeService, MockMD5Hash);

            //Act
            var result = benutzerService.SearchUserByIdNoTracking(id);

            //Assert
            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void SearchUserByEmailTest()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var eMail = benutzer.Mail;
            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(r => r.SearchUserByEMail(It.IsAny<string>())).Returns(benutzer);
            MockBenutzerRepository = mockBenutzerRepository.Object;

            var benutzerService = new BenutzerService(MockBenutzerRepository, MockMailService, MockBenutzerGruppeService, MockMD5Hash);

            //Act
            var result = benutzerService.SearchUserByEmail(eMail);

            //Assert
            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void FindAllBenutzersTest()
        {
            //Assert
           var benutzer = Fixture.Build<Benutzer>().Create();
            var eMail = benutzer.Mail;
            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(r => r.SearchUser());
            MockBenutzerRepository = mockBenutzerRepository.Object;

            var benutzerService = new BenutzerService(MockBenutzerRepository, MockMailService, MockBenutzerGruppeService, MockMD5Hash);

            //Act
            var result = benutzerService.FindAllBenutzers();

            //Assert
            Assert.IsNull(result);
        }
    }
}