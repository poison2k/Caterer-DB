using AutoMapper;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using DataAccess.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;

namespace Caterer_DB.Tests.Benutzergruppentest
{
    [TestFixture]
    public class BenutzerGruppenViewModelTest
    {
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
        public void Map_CreateBenutzerGruppeViewModel_BenutzerGruppe_Test()
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
        public void Map_EditeBenutzerGruppeViewModel_BenutzerGruppe_Test()
        {
            //Assert
            var benutzerGruppe = Fixture.Build<BenutzerGruppe>().Create();
            var editBenutzerGruppeViewModel = Fixture.Build<EditBenutzerGruppeViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<BenutzerGruppe>(It.IsAny<EditBenutzerGruppeViewModel>())).Returns(benutzerGruppe);
            MockMapper = mockMapper.Object;

            var benutzerGruppenViewModelService = new BenutzerGruppeViewModelService();

            //Act
            var result = benutzerGruppenViewModelService.Map_EditBenutzerGruppeViewModel_BenutzerGruppe(editBenutzerGruppeViewModel);

            //Assert

            Assert.AreEqual(benutzerGruppe.GetType(), result.GetType());
        }

        [Test]
        public void Map_DeleteBenutzerGruppeViewModel_BenutzerGruppe_Test()
        {
            //Assert
            var benutzerGruppe = Fixture.Build<BenutzerGruppe>().Create();
            var deleteBenutzerGruppeViewModel = Fixture.Build<DeleteBenutzerGruppeViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<BenutzerGruppe>(It.IsAny<DeleteBenutzerGruppeViewModel>())).Returns(benutzerGruppe);
            MockMapper = mockMapper.Object;

            var benutzerGruppenViewModelService = new BenutzerGruppeViewModelService();

            //Act
            var result = benutzerGruppenViewModelService.Map_DeleteBenutzerGruppeViewModel_BenutzerGruppe(deleteBenutzerGruppeViewModel);

            //Assert

            Assert.AreEqual(benutzerGruppe.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerGruppeViewModel_EditBenutzerGruppe_Test()
        {
            //Assert
            var benutzerGruppe = Fixture.Build<BenutzerGruppe>().Create();
            var editBenutzerGruppeViewModel = Fixture.Build<EditBenutzerGruppeViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<EditBenutzerGruppeViewModel>(It.IsAny<BenutzerGruppe>())).Returns(editBenutzerGruppeViewModel);
            MockMapper = mockMapper.Object;

            var benutzerGruppeViewModelService = new BenutzerGruppeViewModelService();

            //Act
            var result = benutzerGruppeViewModelService.Map_BenutzerGruppe_EditBenutzerGruppeViewModel(benutzerGruppe);

            //Assert

            Assert.AreEqual(editBenutzerGruppeViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerGruppeViewModel_DetailsBenutzerGruppe_Test()
        {
            //Assert
            var benutzerGruppe = Fixture.Build<BenutzerGruppe>().Create();
            var detailsBenutzerGruppeViewModel = Fixture.Build<DetailsBenutzerGruppeViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DetailsBenutzerGruppeViewModel>(It.IsAny<BenutzerGruppe>())).Returns(detailsBenutzerGruppeViewModel);
            MockMapper = mockMapper.Object;

            var benutzerGruppeViewModelService = new BenutzerGruppeViewModelService();

            //Act
            var result = benutzerGruppeViewModelService.Map_BenutzerGruppe_DetailsBenutzerGruppeViewModel(benutzerGruppe);

            //Assert

            Assert.AreEqual(detailsBenutzerGruppeViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_BenutzerGruppeViewModel_DeleteBenutzerGruppe_Test()
        {
            //Assert
            var benutzerGruppe = Fixture.Build<BenutzerGruppe>().Create();
            var deleteBenutzerGruppeViewModel = Fixture.Build<DeleteBenutzerGruppeViewModel>().Create();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DeleteBenutzerGruppeViewModel>(It.IsAny<BenutzerGruppe>())).Returns(deleteBenutzerGruppeViewModel);
            MockMapper = mockMapper.Object;

            var benutzerGruppeViewModelService = new BenutzerGruppeViewModelService();

            //Act
            var result = benutzerGruppeViewModelService.Map_BenutzerGruppe_DeleteBenutzerGruppeViewModel(benutzerGruppe);

            //Assert

            Assert.AreEqual(deleteBenutzerGruppeViewModel.GetType(), result.GetType());
        }
    }
}