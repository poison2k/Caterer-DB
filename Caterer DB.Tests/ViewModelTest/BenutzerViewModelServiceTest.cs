using AutoMapper;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using DataAccess.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using Caterer_DB.Interfaces;
using System.Collections.Generic;
using Common.Interfaces;
using System.Web.Mvc;
using System.Web.Helpers;
using Business.Interfaces;

namespace Caterer_DB.Tests.BenutzerViewModelServiceTest
{
    [TestFixture]
    public class BenutzerViewModelTest
    {
        private IMapper MockMapper { get; set; }
        private IMd5Hash MD5hash { get; set; }
        private IBenutzerService benutzerService { get; set; }
        private IBenutzerService MockService { get; set; }
        private Fixture Fixture { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void IsNotNull_AnmeldenBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var anmeldenBenutzerViewModel = Fixture.Build<AnmeldenBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AnmeldenBenutzerViewModel>(It.IsAny<AnmeldenBenutzerViewModel>())).Returns(anmeldenBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(benutzer);

            //Assert 

            Assert.IsNotNull(anmeldenBenutzerViewModel.Nachname, result.Nachname);
        }

        [Test]
        public void IsNull_AnmeldenBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            benutzer = null;
            var anmeldenBenutzerViewModel = Fixture.Build<AnmeldenBenutzerViewModel>().Create();
            anmeldenBenutzerViewModel = new AnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel.AnmeldenModel = new LoginModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AnmeldenBenutzerViewModel>(It.IsAny<AnmeldenBenutzerViewModel>())).Returns(anmeldenBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(benutzer);

            //Assert 

            Assert.IsNull(anmeldenBenutzerViewModel.Nachname, result.Nachname);
        }

        [Test]
        public void IsNotNull_AnmeldenBenutzerViewModel_ID_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var benutzerId = benutzer.BenutzerId;
            var infobox = "schließen";
            var anmeldenBenutzerViewModel = Fixture.Build<AnmeldenBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AnmeldenBenutzerViewModel>(It.IsAny<AnmeldenBenutzerViewModel>())).Returns(anmeldenBenutzerViewModel);
            MockMapper = mockMapper.Object;
            var mocService = new Mock<IBenutzerService>();
            mocService.Setup(s => s.SearchUserById(1)).Returns(benutzer);
            MockService = mocService.Object;

            

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(benutzerId,infobox);

            //Assert 

            Assert.IsNotNull(anmeldenBenutzerViewModel.Nachname, result.Nachname);
        }

        [Test]
        public void Map_CreateBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var createBenutzerViewModel = Fixture.Build<CreateBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<CreateBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_CreateBenutzerViewModel_Benutzer(createBenutzerViewModel);

            //Assert 

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_EditBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var editBenutzerViewModel = Fixture.Build<EditBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<EditBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel);

            //Assert 

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_MyDataBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var myDataBenutzerViewModel = Fixture.Build<MyDataBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<MyDataBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel);

            //Assert 

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_DeleteBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var deleteBenutzerViewModel = Fixture.Build<DeleteBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<DeleteBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_DeleteBenutzerViewModel_Benutzer(deleteBenutzerViewModel);

            //Assert 

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_EditBenutzer_Test()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var editBenutzerViewModel = Fixture.Build<EditBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<EditBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(editBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_EditBenutzerViewModel(benutzer);

            //Assert 

            Assert.AreEqual(editBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_MyDataBenutzer_Test()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var myDataBenutzerViewModel = Fixture.Build<MyDataBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<MyDataBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(myDataBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(benutzer);

            //Assert 

            Assert.AreEqual(myDataBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_DetailsBenutzer_Test()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var detailsBenutzerViewModel = Fixture.Build<DetailsBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DetailsBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(detailsBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_DetailsBenutzerViewModel(benutzer);

            //Assert 

            Assert.AreEqual(detailsBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_DeleteBenutzer_Test()
        {
            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var deleteBenutzerViewModel = Fixture.Build<DeleteBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DeleteBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(deleteBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_DeleteBenutzerViewModel(benutzer);

            //Assert 

            Assert.AreEqual(deleteBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_RegisterBenutzerViewModel_Benutzer_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var registerBenutzerViewModel = Fixture.Build<RegisterBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<RegisterBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);
            
            //Act
            var result = benutzerViewModelService.Map_RegisterBenutzerViewModel_Benutzer(registerBenutzerViewModel);

            //Assert 

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void CreateNewRegisterBenutzerViewModel_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var createNewRegisterBenutzerViewModel = Fixture.Build<RegisterBenutzerViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<RegisterBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.CreateNewRegisterBenutzerViewModel();

            //Assert 

            Assert.AreEqual(createNewRegisterBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void AddListsToRegisterViewModel_Test()
        {

            //Assert
            var benutzer = Fixture.Build<Benutzer>().Create();
            var registerBenutzerViewModel = Fixture.Build<RegisterBenutzerViewModel>().Create();

            var benutzerViewModelService = new BenutzerViewModelService(benutzerService, MD5hash);

            //Act
            var result = benutzerViewModelService.AddListsToRegisterViewModel(registerBenutzerViewModel);

            //Assert 

            Assert.AreEqual(registerBenutzerViewModel.GetType(), result.GetType());
        }
    }
}
