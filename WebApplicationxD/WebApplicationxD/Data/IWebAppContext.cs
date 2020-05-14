using System.Collections.Generic;
using System.Linq;
using WebApplicationxD.Models;


namespace WebApplicationxD.Data
{
    public interface IWebAppContext
    {
        public IQueryable<Author> Author { get; }
        public IQueryable<Book> Book { get; }
        int SaveChanges();
        Author FindAuthorById(int ID);
        Book FindBookById(int ID);
        Book FindBookByTitle(string Title);

        Author Delete(Author author);
        Book Delete(Book book);

        Author Add(Author author);
        Book Add(Book book);
        Author Update(Author author);
        Book Update(Book book);

    }
}
