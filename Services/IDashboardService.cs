using Books_API.Entities;

namespace Books_API.Services
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboard();
    }
}
