using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplicationxD.Controllers;
using WebApplicationxD.Models;

namespace WebApplicationxDTest.ModelsTests
{
    [TestClass]
    public class AuthorModelTest
    {
        [TestMethod]
        public void Validate_Author_Not_Given_Data()
        {
            var model = new Author();
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Name cannot be null", results[0].ErrorMessage);
            Assert.AreEqual("Nationality cannot be null", results[1].ErrorMessage);
        }

        [TestMethod]
        public void Validate_Author_Name_Only()
        {
            var model = new Author();
            { model.Name = "Adam Marcel"; }
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Nationality cannot be null", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Validate_Author_OK()
        {
            var model = new Author();
            {
                model.Name = "Adam Marcel";
                model.Nationality = "polish";
            };
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Validate_Author_Invalid_Name()
        {
            var model = new Author();
            {
                model.Name = "adam mały";
                model.Nationality = "polish";
            };
            var results = TestModelHelper.Validate(model);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Name should start with letter", results[0].ErrorMessage);
        }

    }
}
