using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantsWeb.Controllers;
using resterauntWeb.Models;

namespace RestaurantsWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            ReviewsController prodController = new ReviewsController(); // ToDo  - mock  DbContext and pass that in

            // Act
            var result = prodController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //    Assert.IsNotNull(result.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            ReviewsController prodController = new ReviewsController(); // ToDo  - mock  DbContext and pass that in

            // Act
            var result = prodController.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //    Assert.IsNotNull(result.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }
        [TestMethod]
        public void TestIndexRestaurant()
        {


        }


        [TestMethod]
        public void TestSortByCity()
        {

      RestaurantsController   Restaurants = new RestaurantsController();
            Restaurant restaurant = new Restaurant();

            Restaurant rest1 = new Restaurant()
            {

                City = "Tampa"
            };
            Restaurant rest2 = new Restaurant()
            {
                City = "Los Angelas"

            };
            Restaurant rest3 = new Restaurant()
            {
                City = "Miami"

            };
            List<Restaurant> mockList = new List<Restaurant>()
            {
                rest1,
                rest2,
                rest3
            };
            List<Restaurant> ExpectedResult = new List<Restaurant>()
            {

                rest3

            };

            //var ActualResult = Restaurants.Inde("City", "Mia") as ViewResult();
          //  CollectionAssert.AreEqual(ExpectedResult, ActualResult);

        }
    }

}
