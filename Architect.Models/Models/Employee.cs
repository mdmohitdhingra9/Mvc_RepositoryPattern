using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architect.Models.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last name contains max 30 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Last name contains max 30 characters.")]
        public string FirstMidName { get; set; }

        [Required]
        [Display(Name = "Date of Bifth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public int? DepartmentId { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string ImageId { get; set; }

        [NotMapped]
        public System.Web.HttpPostedFileBase file { get; set; }

        [ForeignKey("DepartmentId")]
        public Deparment Department { get; set; }
    }
}
