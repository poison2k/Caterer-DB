using AutoMapper;
using Caterer_DB.Models;
using Caterer_DB.Models.ViewModelServices;
using Common.Model;
using MockData;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Tests.ViewModelTest
{
    [TestFixture]
    public class RechteViewModelTest
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
        public void Map_CreateRechtViewModel_Recht_Test()
        {
            //Assert
            var recht = MockRechtModel.EinRecht();
            var createRechtViewModel = new CreateRechtViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Recht>(It.IsAny<CreateRechtViewModel>())).Returns(recht);
            MockMapper = mockMapper.Object;

            var rechtViewModelService = new RechtViewModelService();

            //Act
            var result = rechtViewModelService.Map_CreateRechtViewModel_Recht(createRechtViewModel);

            //Assert

            Assert.AreEqual(recht.GetType(), result.GetType());
        }

        [Test]
        public void Map_EditRechtViewModel_Recht_Test()
        {
            //Assert
            var recht = MockRechtModel.EinRecht();
            var editRechtViewModel = new EditRechtViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Recht>(It.IsAny<EditRechtViewModel>())).Returns(recht);
            MockMapper = mockMapper.Object;

            var rechtViewModelService = new RechtViewModelService();

            //Act
            var result = rechtViewModelService.Map_EditRechtViewModel_Recht(editRechtViewModel);

            //Assert

            Assert.AreEqual(recht.GetType(), result.GetType());
        }

        [Test]
        public void Map_DeleteRechtViewModel_Recht_Test()
        {
            //Assert
            var recht = MockRechtModel.EinRecht();
            var deleteRechtViewModel = new DeleteRechtViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<Recht>(It.IsAny<DeleteRechtViewModel>())).Returns(recht);
            MockMapper = mockMapper.Object;

            var rechtViewModelService = new RechtViewModelService();

            //Act
            var result = rechtViewModelService.Map_DeleteRechtViewModel_Recht(deleteRechtViewModel);

            //Assert

            Assert.AreEqual(recht.GetType(), result.GetType());
        }

        [Test]
        public void Map_RechteViewModel_EditRecht_Test()
        {
            //Assert
            var recht = MockRechtModel.EinRecht();
            var editRechtViewModel = new EditRechtViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<EditRechtViewModel>(It.IsAny<Recht>())).Returns(editRechtViewModel);
            MockMapper = mockMapper.Object;

            var rechtViewModelService = new RechtViewModelService();

            //Act
            var result = rechtViewModelService.Map_Recht_EditRechtViewModel(recht);

            //Assert

            Assert.AreEqual(editRechtViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_RechtViewModel_DetailsRecht_Test()
        {
            //Assert
            var recht = MockRechtModel.EinRecht();
            var detailsRechtViewModel = new DetailsRechtViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DetailsRechtViewModel>(It.IsAny<Recht>())).Returns(detailsRechtViewModel);
            MockMapper = mockMapper.Object;

            var rechtViewModelService = new RechtViewModelService();

            //Act
            var result = rechtViewModelService.Map_Recht_DetailsRechtViewModel(recht);

            //Assert

            Assert.AreEqual(detailsRechtViewModel.GetType(), result.GetType());
        }

        [Test]
        public void Map_RechtViewModel_DeleteRecht_Test()
        {
            //Assert
            var recht = MockRechtModel.EinRecht();
            var deleteRechtViewModel = new DeleteRechtViewModel();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<DeleteRechtViewModel>(It.IsAny<Recht>())).Returns(deleteRechtViewModel);
            MockMapper = mockMapper.Object;

            var rechtViewModelService = new RechtViewModelService();

            //Act
            var result = rechtViewModelService.Map_Recht_DeleteRechtViewModel(recht);

            //Assert

            Assert.AreEqual(deleteRechtViewModel.GetType(), result.GetType());
        }
    }
}