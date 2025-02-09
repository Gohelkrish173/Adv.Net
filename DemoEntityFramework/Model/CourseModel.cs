using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEntityFramework.Model
{
    [Table("Course")]
    public class CourseModel
    {
        #region Properties

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
        #endregion
    }
}
