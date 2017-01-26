using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataAccess.Model;
using System.Collections.Generic;
using Ploeh.AutoFixture;
using UnityAutoMoq;

using DataAccess.Repositories;
using System.Data.Entity;
using DataAccess.Interfaces;
using Microsoft.Practices.Unity;

namespace DataAccess.Test
{
    [TestClass]
    public class BenutzerRepositoryTest : RepoTestBase
    {

        private Mock<DbSet<Benutzer>> dbSetMock;
        protected UnityAutoMoqContainer Container { get; private set; }
        protected Fixture Fixture { get; set; }
       

        [TestInitialize]
        public void Initialize()
        {
            Container = new UnityAutoMoqContainer();
            Fixture = new Fixture();
            Container.RegisterType<IBenutzerRepository, BenutzerRepository>();
        }

        [TestMethod]
        public void SearchUserById_UserWithId1_UserWithId2()
        {
            var repo = GeneriereListeVonBenutzern();
            var benutzer1 =  repo.SearchUserById(1);
            var benutzer2 =  repo.SearchUserById(2);

            Assert.AreEqual(benutzer1.BenutzerId ,1);
            Assert.AreEqual(benutzer1.BenutzerId, 2);
        }



        private void LegeDbSetMockInContext(DbSet<Benutzer> dbSetMock)
        {
            var mockContext = Container.GetMock<ICatererContext>();
            mockContext.Setup(m => m.Benutzer).Returns(dbSetMock);
            mockContext.Setup(m => m.Set<Benutzer>()).Returns(dbSetMock);
        }

        private BenutzerRepository GeneriereListeVonBenutzern()
        {
            int id = 1;
            

            var generierteBenutzer = Fixture
                .Build<Benutzer>()
                .WithAutoProperties()
                .Do(p => p.BenutzerId = id++)
                .OmitAutoProperties()
                .CreateMany<Benutzer>(10);
            var daten = new List<Benutzer>();
            daten.AddRange(generierteBenutzer);

            dbSetMock = VerpackListeInDbSet(daten);


            LegeDbSetMockInContext(dbSetMock.Object);

            var repo = Container.Resolve<BenutzerRepository>();

            return repo;
        }
    }
}
