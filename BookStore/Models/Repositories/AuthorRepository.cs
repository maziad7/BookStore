using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookStoreRepository<Author>
    {
        IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author{Id=1,Fullname = "Maziad"},
                new Author{Id=2,Fullname = "Ahmad"}
            };

        }
        public void add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id);
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = find(id);
            authors.Remove(author);
        }

        public Author find(int id)
        {
            var author=authors.SingleOrDefault(b=>b.Id==id);
            return author;
        }

        public IList<Author> list()
        {
            return authors;
        }

        public void update(int id, Author NewAuthor)
        {
            var author = find(id);

            author.Fullname = NewAuthor.Fullname;
        }
    }
}
