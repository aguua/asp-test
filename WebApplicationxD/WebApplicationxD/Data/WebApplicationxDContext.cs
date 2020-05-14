using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationxD.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WebApplicationxD.Data
{
    public class WebApplicationxDContext : DbContext,  IWebAppContext
    {
        public WebApplicationxDContext(DbContextOptions<WebApplicationxDContext> options)
             : base(options) { }
        public WebApplicationxDContext() { }

        public DbSet<Author> Author { get; set; }

        public DbSet<Book> Book { get; set; }

 
         IQueryable<Author> IWebAppContext.Author
        {
            get { return Author; }
        }

         IQueryable<Book> IWebAppContext.Book
        {
            get { return Book; }
        }

        Book IWebAppContext.FindBookById(int ID)
        {
            return Set<Book>().Find(ID);
        }
        Book IWebAppContext.FindBookByTitle(string Title)
        {
            return Set<Book>().Find(Title);
        }

        Author IWebAppContext.FindAuthorById(int ID)
        {
            return Set<Author>().Find(ID);
        }

        int IWebAppContext.SaveChanges()
        {
            return SaveChanges();
        }

         Author IWebAppContext.Delete(Author author)
        {
            this.Author.Remove(author);
            return author;
        }

        Book IWebAppContext.Delete(Book book)
        {
            this.Book.Remove(book);
            return book;
        }

        Author IWebAppContext.Add(Author author)
        {
            this.Author.Add(author);
            return author;
        }

        Book IWebAppContext.Add(Book book)
        {
            this.Book.Add(book);
            return book;
        }

        Author IWebAppContext.Update(Author author)
        {
            this.Author.Update(author);
            return author;
                
        }

        Book Update(Book book)
        {
            this.Book.Update(book);
            return book;
        }

        Book IWebAppContext.Update(Book book)
        {
            throw new System.NotImplementedException();
        }

    }
}
