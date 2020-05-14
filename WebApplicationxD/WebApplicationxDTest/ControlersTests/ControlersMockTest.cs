using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebApplicationxD;
using WebApplicationxD.Controllers;
using WebApplicationxD.Models;
using Moq;
using WebApplicationxD.Data;
using Microsoft.VisualBasic.CompilerServices;
using WebApplicationxDTest.Doubles;
using System.Threading.Tasks;

namespace WebApplicationxDTest.ControlersTests
{
    [TestClass]
    public class ControlersMockTest
    {
        private Mock<WebApplicationxDContext> _mockContext;   //should be interface here... 
        AuthorsController autController;
        BooksController bookController;

        [TestInitialize]
        public void Init()
        {
            _mockContext = new Mock<WebApplicationxDContext>();
            autController = new AuthorsController(_mockContext.Object);
            bookController = new BooksController(_mockContext.Object);
        }


        //mock 
        [TestMethod]
        public async Task TestAuthor()
        {
            var model = new Author();
            {
                model.Name = "Adam Marcel";
                model.Nationality = "polish";
            };

            //_mockContext.Setup(x => x.Add(model)).Returns(model);

            //_mockContext.Setup(x => x.FindAuthorById(0)).Returns(model);

            var result = await autController.Details(0) as ViewResult;
            var expectedModel = result.Model as Author;
            Assert.AreEqual(model, expectedModel);
        }

        [TestMethod]
        public void TestmOCK()
        {
            Mock<Author> mockAuthor = new Mock<Author>();
            mockAuthor.Setup(X => X.Nationality).Returns("POLISH");
            /*
            [Test]
        public void Save_CustomerIsNotNull_GetsAddedToRepository()
        {
            //Arrange
            Mock<IContainer> mockContainer = new Mock<IContainer>();
            Mock<ICustomerView> mockView = new Mock<ICustomerView>();

            CustomerViewModel viewModel = new CustomerViewModel(mockView.Object, mockContainer.Object);
            viewModel.CustomersRepository = new CustomersRepository();
            viewModel.Customer = new Mock<Customer>().Object;

            //Act
            viewModel.Save();

            //Assert
            Assert.IsTrue(viewModel.CustomersRepository.Count == 1);
        }*/
    }


        [TestMethod]
        public void TestHomeContollerIndex()
        { 
            HomeController controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestHomeContollerPrivacy()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Privacy() as ViewResult;
            Assert.IsNotNull(result);
        }



        [TestMethod]
         public async Task Test_Index_Return_View()
        {
            var result = await autController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }


        [TestCleanup]
        public void Cleanup()
        {
            _mockContext = null;
            autController = null;
            bookController = null;
        }

    }
}
