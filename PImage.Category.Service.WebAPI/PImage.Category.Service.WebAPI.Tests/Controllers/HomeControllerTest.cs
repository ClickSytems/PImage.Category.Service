using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PImage.Category.Service.WebAPI;
using PImage.Category.Service.WebAPI.Controllers;

namespace PImage.Category.Service.WebAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
