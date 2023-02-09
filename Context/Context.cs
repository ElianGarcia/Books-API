using Books_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books_API.Context
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }
        
        public virtual DbSet<Book> Books { get; set; }
    }
}
