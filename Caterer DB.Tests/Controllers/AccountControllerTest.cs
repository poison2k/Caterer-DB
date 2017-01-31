using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caterer_DB;
using Caterer_DB.Controllers;
using Caterer_DB.Models;

namespace Caterer_DB.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void LoginURLTest()
        { 
       
        // Arrange
            AccountController controller = new AccountController();

        // Act
        ViewResult result = controller.Login(null) as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        
        }
    
        [TestMethod]
        public void LoginVorgangTest()
        
        {

        // Arrange
        AccountController controller = new AccountController();
            var loginViewModel = new LoginViewModel()
            {
                Email = "caterer@test.de",
                Password = "Start#22"
            };


        // Act
        var  result =  controller.Login(loginViewModel, null) ;

        // Assert
        //Assert.IsNotNull(result);

        }
    }
}
