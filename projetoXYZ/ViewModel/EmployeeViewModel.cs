using System.ComponentModel.DataAnnotations;

namespace projetoXYZ.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Position { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Office { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Salary { get; set; }
        public string DateString { get; set; } = string.Format("{0: yyyy-MM-dd}", "2019-01-01");
    }
}
