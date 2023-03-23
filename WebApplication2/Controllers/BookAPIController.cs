using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        public static List<Book> _books = new List<Book>();


        public BookAPIController()
        {

        }

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            List<Book> books = new List<Book>(_books);
            return books;
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {

            Book? book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            //book.Id = _books.Count + 1;
            int id = 1;
            if (_books.Count != 0)
            {
                int maxId = _books.Max(b => b.Id);
                id = maxId + 1;
            }
            book.Id = id;

            _books.Add(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
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
            return NoContent();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book? bookToRemove = _books.Find(b => b.Id == id);
            if (bookToRemove == null)
            {
                return NotFound();
            }
            _books.Remove(bookToRemove);
            return NoContent();
        }
    }
}
