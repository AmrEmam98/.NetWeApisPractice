using Microsoft.Identity.Client;

namespace LinkedInProjectApi.Models
{
    public class EmployeeCompany
    {

        public int Id { get; set; }
        public CompanyModel Company { get; set; }

        public EmployeeModel Employee { get; set; }

        public string Position { get; set; }

        public DateTime JoiningDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }



    }
}
