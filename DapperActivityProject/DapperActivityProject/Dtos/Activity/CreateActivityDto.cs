namespace DapperActivityProject.Dtos.Activity
{
    public class CreateActivityDto
    {
        public string Title { get; set; }

        public string TypeName { get; set; }

        public string OrganizationName { get; set; }

        public string CityName { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public int AttendanceCount { get; set; }

        public decimal Budget { get; set; }
    }
}
