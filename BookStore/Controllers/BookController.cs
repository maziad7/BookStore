using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public IBookStoreRepository<Book> BookRepository { get; }
        public IBookStoreRepository<Author> AuthorRepository { get; }

        // GET: Book 
        public BookController(IBookStoreRepository<Book> BookRepository, IBookStoreRepository<Author> AuthorRepository)
        {
            this.BookRepository = BookRepository;
            this.AuthorRepository = AuthorRepository;
        }
        public ActionResult Index()
        {
            var books = BookRepository.list();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = BookRepository.find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModels
            {
                Authors = AuthorRepository.list().ToList()

            };
            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModels model)
        {
            try
            {
                // TODO: Add insert logic here
                var author = AuthorRepository.find(model.AuthorId);
                Book book = new Book
                {
                    Id = model.BookId,
                    title=model.Title,
                    Description =model.Description,
                    Author=author

                };
                BookRepository.add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = BookRepository.find(id);
            var authorId = book.Author == null ? book.Author.Id = 0 : book.Author.Id;
            var view_model = new BookAuthorViewModels
            {
                BookId = book.Id,
                Title=book.title,
                Description =book.Description,
                AuthorId= authorId,
                Authors =AuthorRepository.list().ToList()
            };
            return View(view_model);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookAuthorViewModels viewModels)
        {
            try
            {
                // TODO: Add update logic here
                var author = AuthorRepository.find(viewModels.AuthorId);
                Book book = new Book
                {
                   
                    title = viewModels.Title,
                    Description = viewModels.Description,
                    Author = author

                };
                BookRepository.update(viewModels.BookId,book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = BookRepository.find(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                BookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}