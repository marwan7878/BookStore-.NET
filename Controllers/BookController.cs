using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using ThirdDotNet.Models;
using ThirdDotNet.Models.Repositories;
using ThirdDotNet.ViewModels;

namespace ThirdDotNet.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepository<Book> bookRepository;
        private readonly IBookStoreRepository<Author> authorRepository;
        private readonly IHostingEnvironment hosting;

        public BookController(IBookStoreRepository<Book> bookRepository
            , IBookStoreRepository<Author> authorRepository,IHostingEnvironment hosting )
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.hosting = hosting;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        public IActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                BookId = bookRepository.List().Max(b=>b.Id)+1,
                Authors = FillSelectList()
            };
            return View("/Views/Book/Create.cshtml",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookAuthorViewModel entity)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (entity.AuthorId == -1)
                    {
                        ViewBag.Message = "Please select an author from the list!";
                        return View(GetAllAuthors());
                    }


                    var author = authorRepository.Find(entity.AuthorId);
                    var book = new Book
                    {
                        Id = entity.BookId,
                        Title = entity.Title,
                        Description = entity.Description,
                        author = author
                    };

                    bookRepository.Add(book);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }


            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(GetAllAuthors());

        }

        BookAuthorViewModel GetAllAuthors()
        {
            var model = new BookAuthorViewModel
            {
                Authors = FillSelectList()
            };

            return model;
        }
        public IActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            if (book.author == null)
            {
                book.author.Id = 0;
            }
            var model = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.author.Id,
                Authors = authorRepository.List().ToList()
            };
            return View(model);
        }
        public IActionResult Update(BookAuthorViewModel book)
        {
            var author = authorRepository.Find(book.AuthorId);
            var model = new Book
            {
                Id = book.BookId,
                Title = book.Title,
                Description = book.Description,
                author = author
            };
            bookRepository.Update(book.BookId , model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }
        public IActionResult ConfirmDelete(int id)
        {
            bookRepository.Delete(id);
            
            return View("/Views/Book/Index.cshtml" , bookRepository.List());
        }

        List<Author> FillSelectList()
        {
            var authors = authorRepository.List().ToList();
            authors.Insert(0 , new Author(-1,"--- Please select Author ---"));
            return authors;
        }
    }
}