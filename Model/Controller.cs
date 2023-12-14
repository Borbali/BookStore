using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookContext Context;

        public BookController(BookContext context)
        {
            Context = context;
        }


        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Books.Add(book);
            Context.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpGet("all")]
        public IActionResult GetBooks()
        {
            var books = Context.Books.ToList();

            if (books == null || books.Count == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = Context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            Context.Entry(book).State = EntityState.Modified;
            Context.SaveChanges();

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = Context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            Context.Books.Remove(book);
            Context.SaveChanges();

            return NoContent();
        }


    }
}

