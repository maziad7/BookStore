using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        IList<Book> Books;
        public BookRepository()
        {
            Books = new List<Book>()
            {
                new Book
                {
                    Id =1,
                    title ="c langauge",
                    Description="Nothing",
                    Author=new Author{Id=2}
                },
                new Book
                {
                    Id =2,
                    title ="python langauge",
                    Description ="no data",
                    Author=new Author()
                }
            };
        }
        public void add(Book entity)
        {
            entity.Id = Books.Max(b => b.Id) + 1;
            Books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = find(id);
            Books.Remove(book);
        }

        public Book find(int id)
        {
            var book =Books.SingleOrDefault(b=>b.Id==id);
            return book;
        }

        public IList<Book> list()
        {
            return Books;
        }

        public void update(int id,Book NewBOOK)
        {
            var book = find(id);
            book.title = NewBOOK.title;
            book.Description = NewBOOK.Description;
            book.Author = NewBOOK.Author;
        }
    }
}
