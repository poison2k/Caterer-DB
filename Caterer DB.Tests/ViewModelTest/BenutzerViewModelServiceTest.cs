using AutoMapper;
using Business.Interfaces;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using Common.Interfaces;
using Common.Model;
using MockData;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Linq;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Tests.ViewModelTest
{
    [TestFixture]
    public class BenutzerViewModelTest
    {
        private IMapper MockMapper { get; set; }
        private IMd5Hash MockMD5hash { get; set; }
        private IBenutzerService MockBenutzerService { get; set; }

        private IFrageService MockFrageService { get; set; }
        private Fixture Fixture { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            MockMapper = new Mock<IMapper>().Object;
            MockBenutzerService = new Mock<IBenutzerService>().Object;
            MockFrageService = new Mock<IFrageService>().Object;
            MockMD5hash = new Mock<IMd5Hash>().Object;
        }

        [Test]
        public void IsNotNull_AnmeldenBenutzerViewModel_Benutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinAdministrator();
            var fragen = new List<List<Frage>>();
            var anmeldenBenutzerViewModel = MockAccountViewModels.EinAnmeldenBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AnmeldenBenutzerViewModel>(It.IsAny<AnmeldenBenutzerViewModel>())).Returns(anmeldenBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(benutzer, fragen);

            //Assert

            Assert.IsNotNull(anmeldenBenutzerViewModel.Nachname, result.Nachname);
        }

        [Test]
        public void IsNull_AnmeldenBenutzerViewModel_Benutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinAdministrator();
            var fragen = new List<List<Frage>>();

            benutzer = null;
            var anmeldenBenutzerViewModel = MockAccountViewModels.EinAnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel = new AnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel.AnmeldenModel = new LoginModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AnmeldenBenutzerViewModel>(It.IsAny<AnmeldenBenutzerViewModel>())).Returns(anmeldenBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(benutzer, fragen);

            //Assert

            Assert.IsNull(anmeldenBenutzerViewModel.Nachname, result.Nachname);
        }

        [Test]
        public void IsNotNull_AnmeldenBenutzerViewModel_ID_Test()
        {
            //Assert
            var anmeldenBenutzerViewModel = MockAccountViewModels.EinAnmeldenBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<AnmeldenBenutzerViewModel>(It.IsAny<AnmeldenBenutzerViewModel>())).Returns(anmeldenBenutzerViewModel);
            MockMapper = mockMapper.Object;
            var mockBenutzerService = new Mock<IBenutzerService>();
            mockBenutzerService.Setup(s => s.SearchUserById(It.IsAny<int>())).Returns(MockBenutzerModel.EinMitarbeiter);
            MockBenutzerService = mockBenutzerService.Object;
            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.GeneriereAnmeldenBenutzerViewModel(1);

            //Assert

            Assert.IsNotNull(anmeldenBenutzerViewModel.Nachname, result.Nachname);
        }

        [Test]
        public void Map_CreateMitarbeiterViewModel_Benutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var createMitarbeiterViewModel = new CreateMitarbeiterViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<CreateMitarbeiterViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_CreateMitarbeiterViewModel_Benutzer(createMitarbeiterViewModel);

            //Assert

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_EditBenutzerViewModel_Benutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var editBenutzerViewModel = new EditBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<EditBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_EditBenutzerViewModel_Benutzer(editBenutzerViewModel);

            //Assert

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_MyDataBenutzerViewModel_Benutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var myDataBenutzerViewModel = new MyDataBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<MyDataBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_MyDataBenutzerViewModel_Benutzer(myDataBenutzerViewModel);

            //Assert

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_DeleteBenutzerViewModel_Benutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var deleteBenutzerViewModel = new DeleteBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<DeleteBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_DeleteBenutzerViewModel_Benutzer(deleteBenutzerViewModel);

            //Assert

            Assert.AreEqual(benutzer.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_EditBenutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var editBenutzerViewModel = new EditBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<EditBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(editBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_EditBenutzerViewModel(benutzer);

            //Assert

            Assert.AreEqual(editBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_MyDataBenutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var fragen = new List<List<Frage>>();
            var myDataBenutzerViewModel = new MyDataBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<MyDataBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(myDataBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act

            var result = benutzerViewModelService.Map_Benutzer_MyDataBenutzerViewModel(benutzer, fragen);

            //Assert

            Assert.AreEqual(myDataBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_DetailsBenutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var detailsBenutzerViewModel = new DetailsBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DetailsBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(detailsBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_DetailsBenutzerViewModel(benutzer);

            //Assert

            Assert.AreEqual(detailsBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerViewModel_DeleteBenutzer_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var deleteBenutzerViewModel = new DeleteBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DeleteBenutzerViewModel>(It.IsAny<Benutzer>())).Returns(deleteBenutzerViewModel);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.Map_Benutzer_DeleteBenutzerViewModel(benutzer);

            //Assert

            Assert.AreEqual(deleteBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void CreateNewRegisterBenutzerViewModel_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var createNewRegisterBenutzerViewModel = new RegisterBenutzerViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Benutzer>(It.IsAny<RegisterBenutzerViewModel>())).Returns(benutzer);
            MockMapper = mockMapper.Object;

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.CreateNewRegisterBenutzerViewModel();

            //Assert

            Assert.AreEqual(createNewRegisterBenutzerViewModel.GetType(), result.GetType());
        }

        [Test]
        public void AddListsToRegisterViewModel_Test()
        {
            //Assert
            var benutzer = MockBenutzerModel.EinMitarbeiter();
            var registerBenutzerViewModel = new RegisterBenutzerViewModel();

            var benutzerViewModelService = new BenutzerViewModelService(MockBenutzerService, MockMD5hash, MockFrageService);

            //Act
            var result = benutzerViewModelService.AddListsToRegisterViewModel(registerBenutzerViewModel);

            //Assert

            Assert.AreEqual(registerBenutzerViewModel.GetType(), result.GetType());
        }
    }
}