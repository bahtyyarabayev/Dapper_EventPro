using DapperActivityProject.Dtos.Activity;
using DapperActivityProject.Dtos.Dashboard;

namespace DapperActivityProject.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<List<ResultDashboardCountDto>> GetTop5OrganizationsAsync();
        Task<List<ResultDashboardCountDto>> GetTop5CitiesAsync();
        Task<List<ResultDashboardYearDto>> GetTop5YearsAsync();
        Task<List<ResultDashboardEventDto>> GetTop5AttendedEventsAsync();
        Task<List<ResultDashboardEventDto>> GetTop5BudgetEventsAsync();
    }
}
