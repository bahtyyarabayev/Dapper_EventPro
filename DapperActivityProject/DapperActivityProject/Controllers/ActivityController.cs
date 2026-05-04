using DapperActivityProject.Dtos.Activity;
using DapperActivityProject.Services.ActivityService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DapperActivityProject.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<IActionResult> ActivityList(string title, string typename, string organization, string city, int page = 1)
        {
            var values = await _activityService.GetAllActivityAsync();

            
            var filtered = values.Where(x =>
                (string.IsNullOrEmpty(title) || x.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(typename) || x.TypeName.Contains(typename, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(organization) || x.OrganizationName.Contains(organization, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(city) || x.CityName.Contains(city, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            int pageSize = 100;
          
            int totalCount = filtered.Count;

           
            var pagedData = filtered
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.TotalCount = totalCount;

         
            ViewBag.SearchTitle = title;
            ViewBag.SearchCity = city;

            return View(pagedData);
        }
        [HttpGet]
        public async Task <IActionResult> CreateActivity()
        {

            var allData = await _activityService.GetAllActivityAsync();

            
            ViewBag.Cities = allData?.Select(x => x.CityName).Distinct().OrderBy(x => x).ToList() ?? new List<string>();
            ViewBag.Types = allData?.Select(x => x.TypeName).Distinct().OrderBy(x => x).ToList() ?? new List<string>();
            ViewBag.Orgs = allData?.Select(x => x.OrganizationName).Distinct().OrderBy(x => x).ToList() ?? new List<string>();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateActivity(CreateActivityDto createActivityDto)
        {
            if (ModelState.IsValid)
            {
                await _activityService.CreateActivityAsync(createActivityDto);
                return RedirectToAction("ActivityList");
            }

            var allData = await _activityService.GetAllActivityAsync();

            ViewBag.Cities = allData.Select(x => x.CityName).Distinct().OrderBy(x => x).ToList();
            ViewBag.Types = allData.Select(x => x.TypeName).Distinct().OrderBy(x => x).ToList();
            ViewBag.Orgs = allData.Select(x => x.OrganizationName).Distinct().OrderBy(x => x).ToList();

            return View(createActivityDto); 
        }
        public async Task<IActionResult> DeleteActivity(int id)
        {
            await _activityService.DeleteActivityAsync(id);
            return RedirectToAction("ActivityList");

        }
        [HttpGet]
        public async Task<IActionResult> UpdateActivity(int id)
        {
            var value = await _activityService.GetActivityByIdAsync(id);
            var allData = await _activityService.GetAllActivityAsync();
            ViewBag.Cities = allData.Select(x => x.CityName).Distinct().OrderBy(x => x).ToList();
            ViewBag.Types = allData.Select(x => x.TypeName).Distinct().OrderBy(x => x).ToList();
            ViewBag.Orgs = allData.Select(x => x.OrganizationName).Distinct().OrderBy(x => x).ToList();

           
            return View(value);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(UpdateActivityDto updateActivityDto)
        {
            await _activityService.UpdateActivityAsync(updateActivityDto);
            return RedirectToAction("ActivityList");

        }
    }
    
}
