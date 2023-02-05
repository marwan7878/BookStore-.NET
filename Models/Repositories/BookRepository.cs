using System.Collections.Generic;
using System.Linq;
using ThirdDotNet.Models.Repositories;

namespace ThirdDotNet.Models.Repositories
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        IList<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book(1, "football1", "premierleague1",new Author(1, "maro")),
                new Book(2, "football2", "premierleague2",new Author(2, "maroo")),
                new Book(3, "football3", "premierleague3",new Author(3, "marooo"))

            };

        }

        public void Add(Book newBook)
        {
            books.Add(newBook);
        }

        public void Delete(int id)
        {
            books.Remove(Find(id));
        }

        public Book Find(int id)
        {
            return books.SingleOrDefault(book => book.Id == id);
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book newBook)
        {
            var oldBook = Find(id);
            oldBook.Title = newBook.Title;
            oldBook.Description = newBook.Description;
            oldBook.author = newBook.author;
        }

        
    }

}
