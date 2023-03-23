using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookMVCController : Controller
    {
        public static List<Book> _books = new List<Book>();
        // GET: BookMVCController
        public IActionResult Index()
        {
            //Book book = new Book();
            //book.Title = "Title 1";
            //book.Author = "Author 1";
            //book.Price = 20000;
            //book.Pages = 50;
            //book.Publisher = "Publisher";
            //book.PublicationDate = DateTime.Now;
          
            var books = _books;
              //_books.Add(book);
            return View(books);
        }

        // GET: BookMVCController/Details/5
        public IActionResult Details(int id)
        {

            Book? book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }


            return View(book);
        }

        // GET: BookMVCController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookMVCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            try
            {
                int id = 0;
                if (_books.Count != 0)
                {
                    int maxId = _books.Max(b => b.Id);
                    id = maxId + 1;
                }
                else
                {
                    id = 1;
                }
                book.Id = id;
                _books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookMVCController/Edit/5
        public IActionResult Edit(int id)
        {


            Book? book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookMVCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {

            Book? existingBook = _books.Find(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Pages = book.Pages;
            existingBook.Price = book.Price;
            existingBook.Publisher = book.Publisher;
            existingBook.PublicationDate = book.PublicationDate;
            return RedirectToAction(nameof(Index));
        }

        // GET: BookMVCController/Delete/5
        public IActionResult Delete(int id)
        {
            Book? book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }


            return View(book);
        }

        // POST: BookMVCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Book book)
        {

            Book? bookToRemove = _books.Find(b => b.Id == id);
            if (bookToRemove == null)
            {
                return NotFound();
            }
            _books.Remove(bookToRemove);
            return RedirectToAction(nameof(Index));


        }
    }
}
