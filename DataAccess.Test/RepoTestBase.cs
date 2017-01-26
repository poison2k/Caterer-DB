using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using DataAccess.Test.AsyncQueryProvider;

namespace DataAccess.Test
{
    public class RepoTestBase
    {

        /// <summary>
        /// Nutzt die Klassen aus AsyncQueryProvider um einen Wrapper um eine Liste zu erstellen,
        /// der für asynchrone Repos geht. 
        /// Habe ich aus dem MSDN Artikel: https://msdn.microsoft.com/en-us/data/dn314429.aspx#async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="daten"></param>
        /// <returns></returns>
        public Mock<DbSet<T>> VerpackListeInDbSet<T>(List<T> daten) where T : class
        {
            var queryable = daten.AsQueryable();

            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IDbAsyncEnumerable<T>>()
            .Setup(m => m.GetAsyncEnumerator())
            .Returns(new TestDbAsyncEnumerator<T>(queryable.GetEnumerator()));

            dbSetMock.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(queryable.Provider));

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return dbSetMock;
        }

    }
}
