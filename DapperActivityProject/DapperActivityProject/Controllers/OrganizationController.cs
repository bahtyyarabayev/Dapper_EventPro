using DapperActivityProject.Context;
using DapperActivityProject.Services.OrganizationService;
using Microsoft.AspNetCore.Mvc;

namespace DapperActivityProject.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly OrganizationService _organizationService;

        public OrganizationController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _organizationService.GetAllOrganizationAsync();

            return View(values);
        }
    }
}
