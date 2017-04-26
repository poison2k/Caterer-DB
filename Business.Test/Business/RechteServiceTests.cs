using System.Collections.Generic;
using System.Linq;
using Business.Services;
using DataAccess.Interfaces;
using DataAccess.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Business.Test.Business
{
    [TestFixture]
    public class RechteServiceTests
    {
        public IRechtRepository MockRechtRepository { get; set; }
        private Fixture Fixture { get; set; }
        private RechtService RechtService { get; set; }

        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var rechteListe = new List<Recht>();
            Fixture.AddManyTo(rechteListe);
            Fixture.RepeatCount = 10;
            Fixture.AddManyTo(rechteListe);

            var mockRechtRepository = new Mock<IRechtRepository>();
            mockRechtRepository.Setup(x => x.SearchRight()).Returns(rechteListe);
            mockRechtRepository.Setup(x => x.SearchRightById(It.IsAny<int>())).Returns(Fixture.Build<Recht>().With(x => x.RechtId, 1).Create());
            MockRechtRepository = mockRechtRepository.Object;

            RechtService = new RechtService(MockRechtRepository);
        }

        [Test]
        public void FindAllRightGroups_Test()
        {
            //Arrange

            //Act
            var result = RechtService.FindAllRights();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void SearchRightGroupById_Test()
        {
            //Arrange

            //Act
            var result = RechtService.SearchRightById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.RechtId);
        }
    }
}