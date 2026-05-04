using DapperActivityProject.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace DapperActivityProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboradService)
        {
            _dashboardService = dashboradService;
        }

        public async Task <IActionResult> Index()
        {
            ViewBag.Top5Orgs = await _dashboardService.GetTop5OrganizationsAsync();
            ViewBag.Top5Cities = await _dashboardService.GetTop5CitiesAsync();
            ViewBag.Top5Years = await _dashboardService.GetTop5YearsAsync();
            ViewBag.Top5Attended = await _dashboardService.GetTop5AttendedEventsAsync();
            ViewBag.Top5Budget = await _dashboardService.GetTop5BudgetEventsAsync();
            return View();
        }
    }
}
