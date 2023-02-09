using Books_API.Context;
using Books_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books_API.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly BooksContext _context;

        public DashboardService(BooksContext context)
        {
            _context = context;
        }

        public async Task<Dashboard> GetDashboard()
        {
            var dashboard = new Dashboard();

            dashboard.TotalBooks = await _context.Books.CountAsync();

            dashboard.TotalBooksRegToday = await _context.Books
                .Where(b => b.DateAdded.Date == DateTime.Now.Date)
                .CountAsync();

            dashboard.TotalBooksRegThisMonth = await _context.Books
                .Where(b => b.DateAdded.Month == DateTime.Now.Month)
                .CountAsync();

            return dashboard;
        }

    }
}
