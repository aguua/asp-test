using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web.Razor.Parser.SyntaxTree;
using WebApplicationxD.Data;
using WebApplicationxD.Models;

namespace WebApplicationxDTest.Doubles
{
    class FakeWebAppContext : IWebAppContext
    {

        List<Author> authorStore = new List<Author>();
        List<Book> bookStore = new List<Book>();


        public IQueryable<Author> Author
        {
            get { return authorStore.AsQueryable(); }
            set {}
        }


        public IQueryable<Book> Book
        {
            get { return bookStore.AsQueryable(); }
            set { }
        }


        public Author FindAuthorById(int ID)
        {
            Author item = (from p in this.Author
                           where p.Id == ID
                           select p).First();

            return item;
        }

        public Book FindBookById(int ID)
        {
            Book item = (from p in this.Book
                         where p.Id == ID
                         select p).First();

            return item;
        }

        public Book FindBookByTitle(string Title)
        {
            Book item = (from p in this.Book
                         where p.Title == Title
                         select p).First();

            return item;
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public Author Delete(Author author)
        {
            this.authorStore.Remove(author);
            return author;
        }

        public Book Delete(Book book)
        {
            this.bookStore.Remove(book);
            return book;
        }

        public Author Add(Author author)
        {
            this.authorStore.Add(author);
            return author;
        }

        public Book Add(Book book)
        {
            this.bookStore.Add(book);
            return book;
        }

        public Author Update(Author author)
        {
            return this.FindAuthorById(author.Id);
        }

        public Book Update(Book book)
        {
            return this.FindBookById(book.Id);
        }

    }
}
