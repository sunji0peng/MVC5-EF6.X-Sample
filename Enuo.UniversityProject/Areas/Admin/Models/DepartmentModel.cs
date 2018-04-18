using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.Areas.Admin.Models
{
    public class DepartmentModel
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Display(Name = "Administrator")]
        public int? InstructorID { get; set; }
        public virtual InstructorModel Administrator { get; set; }
        public virtual ICollection<CourseModel> Courses { get; set; }
    }
}