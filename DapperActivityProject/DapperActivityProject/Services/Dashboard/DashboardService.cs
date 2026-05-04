using Dapper;
using DapperActivityProject.Context;
using DapperActivityProject.Dtos.Activity;
using DapperActivityProject.Dtos.Dashboard;

namespace DapperActivityProject.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly ActivityContext _activityContext;

        public DashboardService(ActivityContext activityContext)
        {
            _activityContext = activityContext;
        }
        public async Task<List<ResultDashboardCountDto>> GetTop5OrganizationsAsync()
        {
            string query ="SELECT TOP 5 OrganizationName AS Name, COUNT(*) AS Count FROM Event GROUP BY OrganizationName ORDER BY Count DESC";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDashboardCountDto>(query);
            return values.ToList();
            
        }

        public async Task<List<ResultDashboardCountDto>> GetTop5CitiesAsync()
        {
            string query = "SELECT TOP 5 CityName AS Name, COUNT(*) AS Count, SUM(AttendanceCount) AS TotalAttendance FROM [EtkinlikDb].[dbo].[Event] GROUP BY CityName ORDER BY COUNT(*) DESC";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDashboardCountDto>(query);
            return values.ToList();
        }
        public async Task<List<ResultDashboardYearDto>> GetTop5YearsAsync()
        {
            string query = "SELECT TOP 5 YEAR(StartDate) AS Year, COUNT(*) AS Count FROM Event GROUP BY YEAR(StartDate) ORDER BY Year DESC";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDashboardYearDto>(query);
            return values.ToList();
            
        }

        public async Task<List<ResultDashboardEventDto>> GetTop5AttendedEventsAsync()
        {
           
            string query = "SELECT TOP 5 Title, Budget, AttendanceCount FROM Event ORDER BY Budget DESC";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDashboardEventDto>(query);
            return values.ToList();
            
        }

        public async Task<List<ResultDashboardEventDto>> GetTop5BudgetEventsAsync()
        {
            string query = "SELECT TOP 5 Title, AttendanceCount, Budget FROM Event ORDER BY Budget DESC";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultDashboardEventDto>(query);
            return values.ToList();
            
        }
    }
}