using System.ComponentModel.DataAnnotations;

namespace DeployEntityFramework.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Reference { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
