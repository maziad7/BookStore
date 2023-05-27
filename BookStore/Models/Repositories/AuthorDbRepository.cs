using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Models.Repositories
{
    public class AuthorDbRepository<Author>:IBookStoreRepository<Author>
    {
        BookStoreDbContext db;
        public AuthorDbRepository(BookStoreDbContext _db)
        {
            db = _db;
        }
        public void add(Author entity)
        {
            //entity.Id = authors.Max(b => b.Id);
            db.Authors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author find(int id)
        {
            var author = db.Authors.SingleOrDefault(b => b.Id == id);
            return author;
        }

        public IList<Author> list() => db.Authors.ToList();

        public void update(int id, Author NewAuthor)
        {
            db.Update(NewAuthor);
            db.SaveChanges();
        }
    }
}
