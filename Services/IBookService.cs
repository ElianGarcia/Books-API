using Books_API.Entities;

namespace Books_API.Services
{
    public interface IBookService
    {
        // Get all books
        Task<IEnumerable<Book>> GetBooks();
        
        // Get a book by id
        Task<Book> GetBook(int id);
        
        // Add a book
        Task<Book> AddBook(Book book);

        // Update a book
        Task<bool> UpdateBook(Book book);

        // Delete a book
        Task<bool> DeleteBook(int id);
    }
}
