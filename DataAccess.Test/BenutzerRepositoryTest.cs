using System;
using Moq;
using DataAccess.Model;
using System.Collections.Generic;
using Ploeh.AutoFixture;
using UnityAutoMoq;

using DataAccess.Repositories;
using System.Data.Entity;
using DataAccess.Interfaces;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using System.Linq;

namespace DataAccess.Test
{
    [TestFixture]
    public class BenutzerRepositoryTest : RepoTestBase
    {

        private Mock<DbSet<Benutzer>> dbSetMock;
        protected UnityAutoMoqContainer Container { get; private set; }
        private Fixture Fixture { get; set; }


        [OneTimeSetUp]
        public void TestInit()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void SearchUserById_UserWithId1_UserWithId2()
        {
            

            
        }



        private void LegeDbSetMockInContext(DbSet<Benutzer> dbSetMock)
        {
            var mockContext = Container.GetMock<ICatererContext>();
            mockContext.Setup(m => m.Benutzer).Returns(dbSetMock);
            mockContext.Setup(m => m.Set<Benutzer>()).Returns(dbSetMock);
        }

        
    }
}
