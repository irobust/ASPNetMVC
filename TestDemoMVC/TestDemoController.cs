using DemoMVC.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Web.Models;

namespace TestDemoMVC
{
    [TestClass]
    public class TestDemoController
    {
        private DemoController controller;
        public TestDemoController()
        {
            controller = new DemoController();
        }

        [TestMethod]
        public void TestIndexAction()
        {
            // Arrange

            // Action
            var result = controller.Index() as ViewResult;

            // Assert
            //Assert.AreEqual("Index", result?.ViewName);
            Assert.IsTrue(result?.ViewName == "" || 
                          result?.ViewName == "Index" || 
                          result?.ViewName == null);
        }

        [TestMethod]
        public void TestIndexViewModel()
        {
            // Arrange

            // Act
            var result = controller.Index() as ViewResult;
            var products = (Product[]?) result?.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(products, typeof(Product[]));
            Assert.AreEqual("product A", products?[0]?.Name);
        }

        [TestMethod]
        public void TestIndexViewBag()
        {
            var result = controller.Index() as ViewResult;
            var total = (decimal?)result?.ViewData["total"];
            total = (decimal?)controller.ViewBag.Total;

            Assert.AreEqual(600, total);
        }
    }
}