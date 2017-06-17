using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeltaImpuls2.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1.Controllers
{
    [TestClass]
    public class membersControllerTest
    {
        membersController controller = new membersController();
        [TestMethod]
        public void members_Index()
        {
            // Act
            ViewResult result = controller.Index("", null, null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void members_Create()
        {
            // Act
            ViewResult result = controller.Create() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void members_Edit()
        {
            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void members_Delete()
        {
            // Act
            ViewResult result = controller.Delete(2) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void members_DeleteConfirmed()
        {
            // Act
            ViewResult result = controller.DeleteConfirmed(2) as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
