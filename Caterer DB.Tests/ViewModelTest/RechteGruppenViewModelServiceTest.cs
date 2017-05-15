using System.Linq;
using AutoMapper;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using Common.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using MockData;

namespace Caterer_DB.Tests.ViewModelTest
{
    [TestFixture]
    public class RechteGruppenViewModelTest
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
        public void Map_CreateRechterGruppeViewModel_RechteGruppe_Test()
        {
            //Assert
            var rechteGruppe = MockRechteGruppeModel.AdminRechteGruppe();
            var createRechteGruppeViewModel = new CreateRechteGruppeViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<RechteGruppe>(It.IsAny<CreateRechteGruppeViewModel>())).Returns(rechteGruppe);
            MockMapper = mockMapper.Object;

            var rechteGruppeViewModelService = new RechteGruppeViewModelService();

            //Act
            var result = rechteGruppeViewModelService.Map_CreateRechteGruppeViewModel_RechteGruppe(createRechteGruppeViewModel);

            //Assert

            Assert.AreEqual(rechteGruppe.GetType(), result.GetType());
        }

        [Test]
        public void Map_EditRechteGruppeViewModel_RechteGruppe_Test()
        {
            //Assert
            var rechteGruppe = MockRechteGruppeModel.AdminRechteGruppe();
            var editRechteGruppeViewModel = new EditRechteGruppeViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<RechteGruppe>(It.IsAny<EditRechteGruppeViewModel>())).Returns(rechteGruppe);
            MockMapper = mockMapper.Object;

            var rechteGruppeViewModelService = new RechteGruppeViewModelService();

            //Act
            var result = rechteGruppeViewModelService.Map_EditRechteGruppeViewModel_RechteGruppe(editRechteGruppeViewModel);

            //Assert

            Assert.AreEqual(rechteGruppe.GetType(), result.GetType());
        }

        [Test]
        public void Map_DeleteRechteGruppeViewModel_RechteGruppe_Test()
        {
            //Assert
            var rechteGruppe = MockRechteGruppeModel.AdminRechteGruppe();
            var deleteRechteGruppeViewModel = new DeleteRechteGruppeViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<RechteGruppe>(It.IsAny<DeleteRechteGruppeViewModel>())).Returns(rechteGruppe);
            MockMapper = mockMapper.Object;

            var rechteGruppeViewModelService = new RechteGruppeViewModelService();

            //Act
            var result = rechteGruppeViewModelService.Map_DeleteRechteGruppeViewModel_RechteGruppe(deleteRechteGruppeViewModel);

            //Assert

            Assert.AreEqual(rechteGruppe.GetType(), result.GetType());
        }

        [Test]
        public void Map_RechteGruppeViewModel_EditRechteGruppe_Test()
        {
            //Assert
            var rechteGruppe = MockRechteGruppeModel.AdminRechteGruppe();
            var editRechteGruppeViewModel = new EditRechteGruppeViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<EditRechteGruppeViewModel>(It.IsAny<RechteGruppe>())).Returns(editRechteGruppeViewModel);
            MockMapper = mockMapper.Object;

            var rechteGruppeViewModelService = new RechteGruppeViewModelService();

            //Act
            var result = rechteGruppeViewModelService.Map_RechteGruppe_EditRechteGruppeViewModel(rechteGruppe);

            //Assert

            Assert.AreEqual(editRechteGruppeViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_RechteGruppeViewModel_DetailsRechteGruppe_Test()
        {
            //Assert
            var rechteGruppe = MockRechteGruppeModel.AdminRechteGruppe();
            var detailsRechteGruppeViewModel = new DetailsRechteGruppeViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DetailsRechteGruppeViewModel>(It.IsAny<RechteGruppe>())).Returns(detailsRechteGruppeViewModel);
            MockMapper = mockMapper.Object;

            var rechteGruppeViewModelService = new RechteGruppeViewModelService();

            //Act
            var result = rechteGruppeViewModelService.Map_RechteGruppe_DetailsRechteGruppeViewModel(rechteGruppe);

            //Assert

            Assert.AreEqual(detailsRechteGruppeViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_RechteGruppeViewModel_DeleteRechteGruppe_Test()
        {
            //Assert
            var rechteGruppe = MockRechteGruppeModel.AdminRechteGruppe();
            var deleteRechteGruppeViewModel = new DeleteRechteGruppeViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DeleteRechteGruppeViewModel>(It.IsAny<RechteGruppe>())).Returns(deleteRechteGruppeViewModel);
            MockMapper = mockMapper.Object;

            var rechteGruppeViewModelService = new RechteGruppeViewModelService();

            //Act
            var result = rechteGruppeViewModelService.Map_RechteGruppe_DeleteRechteGruppeViewModel(rechteGruppe);

            //Assert

            Assert.AreEqual(deleteRechteGruppeViewModel.GetType(), result.GetType());
        }
    }
}