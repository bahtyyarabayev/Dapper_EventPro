using DapperActivityProject.Dtos.Organization;

namespace DapperActivityProject.Services.OrganizationService
{
    public interface IOrganizationService
    {
        Task<List<ResultOrganizationDto>>GetAllOrganizationAsync();
    }
}
