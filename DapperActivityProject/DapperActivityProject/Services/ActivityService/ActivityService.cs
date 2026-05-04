using Dapper;
using DapperActivityProject.Context;
using DapperActivityProject.Dtos.Activity;

namespace DapperActivityProject.Services.ActivityService
{
    public class ActivityService:IActivityService
    {
        private readonly ActivityContext _activityContext;

        public ActivityService(ActivityContext activityContext)
        {
            _activityContext = activityContext;
        }
        public async Task CreateActivityAsync(CreateActivityDto createActivityDto)
        {
            string query = "Insert Into Event (Title,TypeName,OrganizationName,CityName,StartDate,EndDate,AttendanceCount,Budget) values(@title,@typename,@organizationname,@cityname,@startdate,@enddate,@attendancecount,@budget)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createActivityDto.Title);
            parameters.Add("@typename", createActivityDto.TypeName);
            parameters.Add("@organizationname", createActivityDto.OrganizationName);
            parameters.Add("@cityname", createActivityDto.CityName);
            parameters.Add("@startdate", createActivityDto.StartDate);
            parameters.Add("@enddate", createActivityDto.EndDate);
            parameters.Add("@attendancecount", createActivityDto.AttendanceCount);
            parameters.Add("@budget", createActivityDto.Budget);
            var connection = _activityContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task DeleteActivityAsync(int id)
        {
            string query = "Delete From Event Where EventId=@eventid";
            var parameters = new DynamicParameters();
            parameters.Add("@eventid", id);
            var connection = _activityContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultActivityDto>> GetAllActivityAsync()
        {
            string query = "Select*From Event";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultActivityDto>(query);
            return values.ToList();
        }

        public async Task<GetActivityByIdDto> GetActivityByIdAsync(int id)
        {
            string query = "Select * From Event where EventId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _activityContext.CreateConnection();
            var value = await connection.QueryFirstAsync<GetActivityByIdDto>(query, parameters);
            return value;

        }

        public async Task UpdateActivityAsync(UpdateActivityDto updateActivityDto)
        {
            string query = "Update Event Set Title=@title,TypeName=@typename,OrganizationName=@organizationname,CityName=@cityname,StartDate=@startdate,EndDate=@enddate,AttendanceCount=@attendancecount,Budget=@budget Where EventId=@eventid";
            var parameters = new DynamicParameters();
            parameters.Add("@eventid", updateActivityDto.EventId);
            parameters.Add("@title", updateActivityDto.Title);
            parameters.Add("@typename", updateActivityDto.TypeName);
            parameters.Add("@organizationname", updateActivityDto.OrganizationName);
            parameters.Add("@cityname", updateActivityDto.CityName);
            parameters.Add("@startdate", updateActivityDto.StartDate);
            parameters.Add("@enddate", updateActivityDto.EndDate);
            parameters.Add("@attendancecount", updateActivityDto.AttendanceCount);
            parameters.Add("@budget", updateActivityDto.Budget);
            var connection = _activityContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

    }
}
