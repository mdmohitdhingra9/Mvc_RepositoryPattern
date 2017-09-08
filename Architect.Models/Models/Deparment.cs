using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architect.Models.Models
{

    public class Deparment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum department name length is 20")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }


        //public ICollection<Employee> Employees { get; set; }

        //public DateTime? CreateDateTime { get; set; }
    }
}
