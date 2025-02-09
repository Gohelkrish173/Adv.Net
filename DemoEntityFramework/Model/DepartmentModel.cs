using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEntityFramework.Model
{
    [Table("Department")]
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
    }
}
