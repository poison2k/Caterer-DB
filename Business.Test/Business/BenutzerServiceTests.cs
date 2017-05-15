using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Common.Interfaces;
using DataAccess.Interfaces;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using MockData;
using System.Data.Entity.Spatial;
using System;
using Common.Model;

namespace Business.Test.Business
{
    [TestFixture]
    public class BusinessBenutzerServiceTest
    {
        private IBenutzerRepository MockBenutzerRepository { get; set; }
        private IBenutzerGruppeService MockBenutzerGruppeService { get; set; }
        private IMailService MockMailService { get; set; }
        private IDocxService MockDocumentService { get; set; }
        private IMd5Hash MockMd5Hash { get; set; }

        private IGoogleService MockGoogleService { get; set; }

        private IConfigService MockConfigService { get; set; }
        private IMapper MockMapper { get; set; }
        private Fixture Fixture { get; set; }
        private BenutzerService BenutzerService { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

           

            var mockBenutzerRepository = new Mock<IBenutzerRepository>();
            mockBenutzerRepository.Setup(x => x.SearchUser()).Returns(MockBenutzerModel.CatererListe);
            mockBenutzerRepository.Setup(x => x.SearchAllUserByUserGroupWithPagingOrderByCategory(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DbGeography>(),It.IsAny<string>())).Returns(MockBenutzerModel.CatererListe());
            mockBenutzerRepository.Setup(x => x.SearchAllCatererWithPaging(It.IsAny<int>(), It.IsAny<int>())).Returns(MockBenutzerModel.CatererListe());
            mockBenutzerRepository.Setup(x => x.SearchUserById(It.IsAny<int>())).Returns(MockBenutzerModel.EinCaterer());
            mockBenutzerRepository.Setup(x => x.SearchUserByIdNoTracking(It.IsAny<int>())).Returns(MockBenutzerModel.EinCaterer());
            mockBenutzerRepository.Setup(x => x.SearchUserByEMail(It.IsAny<string>())).Returns(MockBenutzerModel.EinCaterer());
            mockBenutzerRepository.Setup(x => x.GetMitarbeiterCount()).Returns(10);
            mockBenutzerRepository.Setup(x => x.AddUser(It.IsAny<Benutzer>()));
            mockBenutzerRepository.Setup(x => x.EditUser(It.IsAny<Benutzer>()));
            mockBenutzerRepository.Setup(x => x.RemoveUser(It.IsAny<Benutzer>()));
            MockBenutzerRepository = mockBenutzerRepository.Object;

            var mockBenutzerGruppeService = new Mock<IBenutzerGruppeService>();
            mockBenutzerGruppeService.Setup(x => x.SearchGroupByBezeichnung(It.IsAny<string>())).Returns(MockBenutzerGruppeModel.AdminBenutzerGruppe());
            MockBenutzerGruppeService = mockBenutzerGruppeService.Object;

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(s => s.Map<Benutzer, Benutzer>(It.IsAny<Benutzer>(), It.IsAny<Benutzer>()));
            MockMapper = mockMapper.Object;

            var mockMd5Hash = new Mock<IMd5Hash>();
            mockMd5Hash.Setup(s => s.CalculateMD5Hash(It.IsAny<string>())).Returns("TestHash");
            MockMd5Hash = mockMd5Hash.Object;

            var mockDocumentService = new Mock<IDocxService>();
            MockDocumentService = mockDocumentService.Object;

            var mockConfigService = new Mock<IConfigService>();
            MockConfigService = mockConfigService.Object;

            var mockGoogleService = new Mock<IGoogleService>();
            MockGoogleService = mockGoogleService.Object;

            var mockMailService = new Mock<IMailService>();
            mockMailService.Setup(x => x.SendForgottenPasswordMail( It.IsAny<Config>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            mockMailService.Setup(x => x.SendNewMitarbeiterMail(It.IsAny<Config>(),It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            mockMailService.Setup(x => x.SendRegisterMail(It.IsAny<Config>(),It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            MockMailService = mockMailService.Object;

            BenutzerService = new BenutzerService(MockBenutzerRepository, MockMailService, MockBenutzerGruppeService, MockMd5Hash,MockDocumentService, MockConfigService, MockGoogleService);
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
            var result = BenutzerService.FindAllMitarbeiterWithPaging(1, 10, "test");

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
            var benutzerService = new BenutzerService(mockBenutzerRepository.Object, MockMailService, MockBenutzerGruppeService, MockMd5Hash, MockDocumentService, MockConfigService, MockGoogleService);

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
        public void VerifyRegistration_BenutzerAndVerifyOK_verifyCodeGuilty_Test()
        {
            //Assert

            //Act
            var result = BenutzerService.VerifyRegistration("1", "TestHash");

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
            Assert.AreEqual(10, result);
        }
    }
}