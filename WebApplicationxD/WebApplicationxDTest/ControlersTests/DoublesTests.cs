using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationxD.Controllers;
using WebApplicationxDTest.Doubles;

namespace WebApplicationxDTest.ControlersTests
{
    [TestClass]
    class DoublesTests
    {
        private FakeWebAppContext _fakeContext;
        AuthorsController autController;
        BooksController bookController;

        [TestInitialize]
        public void Init()
        {
            _fakeContext = new FakeWebAppContext();
            //autController = new AuthorsController(_fakeContext);
           // bookController = new BooksController(_fakeContext);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _fakeContext = null;
            autController = null;
            bookController = null;
        }
    }
}
