using Books_API.Entities;
using Books_API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books_API.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // genera endpoints retornando HttpStatusCode según el standard de rest api (200, 201, 204, 400, 404, 500, etc)
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _bookService.GetBooks();
                return Ok(books);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET api/<BooksController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var book = await _bookService.GetBook(id);
                if (book == null)
                    return NotFound();
                return Ok(book);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();
                var createdBook = await _bookService.AddBook(book);
                return CreatedAtAction(nameof(GetBook), new { id = createdBook.BookId }, createdBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new book record");
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                if (id != book.BookId)
                    return BadRequest("Book ID mismatch");
                var bookToUpdate = await _bookService.GetBook(id);
                if (bookToUpdate == null)
                    return NotFound($"Book with Id = {id} not found");
                return Ok(await _bookService.UpdateBook(book));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var bookToDelete = await _bookService.GetBook(id);
                if (bookToDelete == null)
                {
                    return NotFound($"Book with Id = {id} not found");
                }
                return Ok(await _bookService.DeleteBook(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


    }
}
