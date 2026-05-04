using DapperActivityProject.Dtos.Activity;

namespace DapperActivityProject.Services.ActivityService
{
    public interface IActivityService
    {
        Task<List<ResultActivityDto>> GetAllActivityAsync();

        Task<GetActivityByIdDto> GetActivityByIdAsync(int id);

        Task CreateActivityAsync(CreateActivityDto createActivityDto);

        Task UpdateActivityAsync(UpdateActivityDto updateActivityDto);

        Task DeleteActivityAsync(int id);
    }
}
