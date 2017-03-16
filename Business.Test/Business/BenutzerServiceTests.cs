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
        private IBenutzerRepository MockBenutzerRepository { get; set; }
        private IBenutzerGruppeService MockBenutzerGruppeService { get; set; }
        private IMailService MockMailService { get; set; }
        private IMd5Hash MockMD5Hash { get; set; }
        private IMapper MockMapper { get; set; }
        private Fixture Fixture { get; set; }
        private BenutzerService BenutzerService { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var benutzerList = new List<Benutzer>();
            Fixture.AddManyTo(benutzerList);
            Fixture.RepeatCount = 10;
            Fixture.AddManyTo(benutzerList);

            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(x => x.SearchUser()).Returns(benutzerList);
            mockBenutzerRepository.Setup(x => x.SearchAllCatererWithPaging(It.IsAny<int>(), It.IsAny<int>())).Returns(benutzerList);
            mockBenutzerRepository.Setup(x => x.SearchUserById(It.IsAny<int>())).Returns(Fixture.Build<Benutzer>().With(x => x.BenutzerId, 1).With(x => x.EMailVerificationCode, "TestHash").With(x => x.PasswordVerificationCode, "TestHash").Create());
            mockBenutzerRepository.Setup(x => x.SearchUserByIdNoTracking(It.IsAny<int>())).Returns(Fixture.Build<Benutzer>().With(x => x.BenutzerId, 1).Create());
            mockBenutzerRepository.Setup(x => x.SearchUserByEMail(It.IsAny<string>())).Returns(Fixture.Build<Benutzer>().With(x => x.Mail, "test@test.de").Create());
            mockBenutzerRepository.Setup(x => x.GetMitarbeiterCount()).Returns(10);
            mockBenutzerRepository.Setup(x => x.AddUser(It.IsAny<Benutzer>()));
            mockBenutzerRepository.Setup(x => x.EditUser(It.IsAny<Benutzer>()));
            mockBenutzerRepository.Setup(x => x.RemoveUser(It.IsAny<Benutzer>()));
            MockBenutzerRepository = mockBenutzerRepository.Object;

            var mockBenutzerGruppeService = new Mock<IBenutzerGruppeService>();
            mockBenutzerGruppeService.Setup(x => x.SearchGroupByBezeichnung(It.IsAny<string>())).Returns(Fixture.Build<BenutzerGruppe>().With(x => x.Bezeichnung, "TestBezeichnung").Create());
            MockBenutzerGruppeService = mockBenutzerGruppeService.Object;

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(s => s.Map<Benutzer, Benutzer>(It.IsAny<Benutzer>(), It.IsAny<Benutzer>()));
            MockMapper = mockMapper.Object;

            var mockMd5Hash = new Mock<IMd5Hash>();
            mockMd5Hash.Setup(s => s.CalculateMD5Hash(It.IsAny<string>())).Returns("TestHash");
            MockMD5Hash = mockMd5Hash.Object;

            var mockMailService = new Mock<IMailService>();
            mockMailService.Setup(x => x.SendForgottenPasswordMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            mockMailService.Setup(x => x.SendNewMitarbeiterMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            mockMailService.Setup(x => x.SendRegisterMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            MockMailService = mockMailService.Object;

            BenutzerService = new BenutzerService(MockBenutzerRepository, MockMailService, MockBenutzerGruppeService, MockMD5Hash);



        }


        [Test]
        public void SearchUserById_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.SearchUserById(1);

            //Assert
            Assert.IsNotNull(result.GetType());
            Assert.AreEqual(1, result.BenutzerId);

        }

        [Test]
        public void SearchUserByIdNoTracking_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.SearchUserByIdNoTracking(1);

            //Assert
            Assert.IsNotNull(result.GetType());
            Assert.AreEqual(1, result.BenutzerId);
        }

        [Test]
        public void SearchUserByEmail_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.SearchUserByEmail("test@test.de");

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test@test.de", result.Mail);
        }

        [Test]
        public void FindAllBenutzers_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.FindAllBenutzers();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }


        [Test]
        public void FindAllMitarbeiterWithPaginng_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.FindAllMitarbeiterWithPaging(1,10,"test");

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void CheckEmailForRegistration_SearchUserByEMailReturnsNull_Test()
        {
            //Assert
            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(x => x.SearchUserByEMail(It.IsAny<string>())).Returns(((Benutzer)null));
            var benutzerService = new BenutzerService(mockBenutzerRepository.Object, MockMailService, MockBenutzerGruppeService, MockMD5Hash);

            //Act
            var result = benutzerService.CheckEmailForRegistration("test@test.de");

            //Assert
            Assert.AreEqual(true, result);

        }

        [Test]
        public void CheckEmailForRegistration_SearchUserByEMailReturnsObject_Test()
        {
            //Assert


            //Act
            var result = BenutzerService.CheckEmailForRegistration("test@test.de");

            //Assert
            Assert.AreEqual(false, result);
        }


        [Test]
        public void  VerifyRegistration_BenutzerAndVerifyOK_verifyCodeGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyRegistration("1","TestHash");

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void VerifyRegistration_BenutzerAndVerifyOK_verifyCodeNotGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyRegistration("1", "FalseTestHash");

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void VerifyRegistration_BenutzerORVerifyNotOk_verifyCodeNotGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyRegistration("1", null);

            //Assert
            Assert.AreEqual(false, result);
        }


        [Test]
        public void VerifyPasswordChange_BenutzerAndVerifyOK_verifyCodeGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyPasswordChange("1", "TestHash");

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void VerifyPasswordChange_BenutzerAndVerifyOK_verifyCodeNotGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyPasswordChange("1", "FalseTestHash");

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void VerifyPasswordChange_BenutzerOrVerifyNotOK_verifyCodeNotGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyPasswordChange("1", null);

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetMitarbeiterCount_Test()
        { 
            //Assert

            //Act
            var result = BenutzerService.GetMitarbeiterCount();

            //Assert
            Assert.AreEqual(10,result);

        }

    }
}