using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationxD.Models;

namespace WebApplicationxDTest.ModelsTests
{
    [TestClass]
    public class BookModelTest
    {


        [TestMethod]
        public void Validate_Book_Not_Given_Data()
        {
            var model = new Book();
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("The Title field is required.", results[0].ErrorMessage);
            Assert.AreEqual("Category cannot be null", results[1].ErrorMessage);
            Assert.AreEqual("Please choose author", results[2].ErrorMessage);
        }

        [TestMethod]
        public void Validate_Book_Title_Only()
        {
            var model = new Book();
            {
                model.Title = "Miecz Prawdy";
            }
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Category cannot be null", results[0].ErrorMessage);
            Assert.AreEqual("Please choose author", results[1].ErrorMessage);
        }

        [TestMethod]
        public void Validate_Book_Title_And_Cathegory()
        {
            var model = new Book();
            {
                model.Title = "Miecz Prawdy";
                model.Category = "fantastyka";
            }
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Please choose author", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Validate_Book_Invalid_ReleaseDate()
        {
            Mock<Author> mockAuthor = new Mock<Author>();
            var model = new Book();
            {
                model.Title = "Miecz Prawdy";
                model.Category = "fantastyka";
                model.Author = mockAuthor.Object;
                model.ReleaseDate = new DateTime(3000, 1, 1);
            }
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Can not add not realised book.", results[0].ErrorMessage);

        }


        [TestMethod]
        public void Validate_Book_With_Mocked_Author()
        {
            Mock<Author> mockAuthor = new Mock<Author>();
            mockAuthor.Setup(x => x.Id).Returns(1);
            mockAuthor.Setup(x => x.Name).Returns("Adam");
            var model = new Book();
            {
                model.Title = "Miecz Prawdy";
                model.Category = "fantastyka";
                model.Author = mockAuthor.Object;
            }
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(0, results.Count);
        }


    }
}
