using Books_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // GET: api/<DashboardController>
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            try
            {
                var dashboard = await _dashboardService.GetDashboard();
                return Ok(dashboard);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
