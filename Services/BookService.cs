using Books_API.Entities;
using Books_API.Context;
using Microsoft.EntityFrameworkCore;

namespace Books_API.Services
{
    public class BookService : IBookService
    {
        private readonly BooksContext _context;

        public BookService(BooksContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book book)
        {
            try
            {
                var bookExists = await _context.Books.FirstOrDefaultAsync(x => x.ISBN == book.ISBN);
                if (bookExists != null)
                    throw new Exception("Book with same ISBN already exists");
                
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                
                var bookSaved = await _context.Books.FirstOrDefaultAsync(x => x.ISBN == book.ISBN);
                return bookSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Entry(book).State = EntityState.Deleted;
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    throw new Exception("Book not found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Book> GetBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book != null)
                    return book;
                else
                    throw new Exception("Book not found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return books;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                var bookToUpdate = await _context.Books.FindAsync(book.BookId);

                if (bookToUpdate != null)
                {
                    bookToUpdate.Title = book.Title;
                    bookToUpdate.Author = book.Author;
                    bookToUpdate.Category = book.Category;
                    bookToUpdate.YearOfPublication = book.YearOfPublication;
                    bookToUpdate.Quantity = book.Quantity;
                    
                    _context.Entry(bookToUpdate).State = EntityState.Modified;
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    throw new Exception("Book not found");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
