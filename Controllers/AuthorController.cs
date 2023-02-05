using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdDotNet.Models;
using ThirdDotNet.Models.Repositories;

namespace ThirdDotNet.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookStoreRepository<Author> authorRepository;
        
        public AuthorController(IBookStoreRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var authors = authorRepository.List();
            return View(authors);
        }

        public IActionResult Create()
        {
            var model = new Author
            {
                Id = authorRepository.List().Last().Id+1
            };
            
            return View("/Views/Author/Create.cshtml" ,model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            try
            {
                authorRepository.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        public IActionResult Edit(int id)
        {
            var author = authorRepository.Find(id);
            return View("/Views/Author/Edit.cshtml",author);
        }
        
        
        public IActionResult Update(int id ,Author author)
        {
            authorRepository.Update(id , author);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var author = authorRepository.Find(id);
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var author = authorRepository.Find(id);
            return View("/Views/Author/Delete.cshtml" , author);
        }
        public IActionResult ConfirmDelete(int id)
        {
            authorRepository.Delete(id);
            
            return View("/Views/Author/Index.cshtml" , authorRepository.List());
        }
    }
}