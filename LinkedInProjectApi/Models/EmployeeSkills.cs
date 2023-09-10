using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedInProjectApi.Models
{
    [Table("EmployeeSkills")]
    public class EmployeeSkills
    {
       public int Id { get; set; }

        public EmployeeModel Employee{ get; set; }

        public SkillModel Skill{ get; set; }
    }
}
