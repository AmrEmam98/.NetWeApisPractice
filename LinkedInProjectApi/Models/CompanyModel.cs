using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedInProjectApi.Models
{
    public class CompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required , MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string About { get; set; }

    }
}
