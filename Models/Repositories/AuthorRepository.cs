using System.Collections.Generic;
using System.Linq;

namespace ThirdDotNet.Models.Repositories
{
    public class AuthorRepository : IBookStoreRepository<Author>
    {
        IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author(1 ,"maro"),
                new Author(2 ,"maroo"),
                new Author(3 ,"marooo")
            };

        }
        public void Add(Author newAuthor)
        {
            authors.Add(newAuthor);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            return authors.SingleOrDefault(author => author.Id == id);
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var oldAuthor = Find(id);
            oldAuthor.Name = newAuthor.Name;
        }
    }
}
