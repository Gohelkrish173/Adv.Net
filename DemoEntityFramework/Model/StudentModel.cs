using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEntityFramework.Model
{
    [Table("Student")]
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Enrollment {  get; set; }
        [Required]
        public int Semester {  get; set; }
    }
}
