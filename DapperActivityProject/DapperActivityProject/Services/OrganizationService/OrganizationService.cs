using Dapper;
using DapperActivityProject.Context;
using DapperActivityProject.Dtos.Organization;

namespace DapperActivityProject.Services.OrganizationService
{
    public class OrganizationService:IOrganizationService
    {
        private readonly ActivityContext _activityContext;

        public OrganizationService(ActivityContext activityContext)
        {
            _activityContext = activityContext;
        }
        public async Task<List<ResultOrganizationDto>> GetAllOrganizationAsync()
        {
            string query = "Select*From Organization";
            var connection = _activityContext.CreateConnection();
            var values = await connection.QueryAsync<ResultOrganizationDto>(query);
            return values.ToList();
        }
    }
}
