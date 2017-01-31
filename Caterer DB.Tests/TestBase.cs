using DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAutoMoq;

namespace Caterer_DB.Tests
{
  
        public abstract class TestBase
        {
            private bool registered;

            protected UnityAutoMoqContainer Container { get; private set; }

            protected abstract ApplicationUser AktuellerNutzer { get; }

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

            /// <summary>
            ///     Wird von der Oberklasse zu Begin einmal aufgerufen.
            ///     AktuellerNutzer EffectiveDateingsRatingonHoldingsRatingipmentHoldingsRatinglStrenghtRatingsStatusCategoryalCategorynitamestärkeh über ein IFindeAktuellenNutzer Mock
            ///     Registriert.
            /// </summary>
            /// <returns></returns>
            protected abstract UnityAutoMoqContainer RegisterTypes(UnityAutoMoqContainer container);
        }
    
}
