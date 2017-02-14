using Caterer_DB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityAutoMoq;

namespace Caterer_DB.Tests
{

    public abstract class TestBase
        {
            private bool registered;

            protected UnityAutoMoqContainer Container { get; private set; }

            protected abstract UserModel AktuellerNutzer { get; }

            [TestInitialize]
            public void setUpBase()
            {
                if (!registered)
                {
                    var container = new UnityAutoMoqContainer();
                    Container = RegisterTypes(container);

                    registered = true;
                }
            }

           protected abstract UnityAutoMoqContainer RegisterTypes(UnityAutoMoqContainer container);
        }
    
}
