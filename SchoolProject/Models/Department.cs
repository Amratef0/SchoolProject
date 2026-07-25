using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property: a Department has many Students
        public List<Student>? Students { get; set; }
    }
}
