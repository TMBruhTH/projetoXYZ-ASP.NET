using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoXYZ.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Position { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Office { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
