using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.Areas.Admin.Models
{
    public class CourseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        [Index,StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Range(0, 5)]
        public int Credits { get; set; }
        [Display(Name ="Department")]
        public int? DepartmentID { get; set; }
        public virtual DepartmentModel Department { get; set; }

        public virtual ICollection<EnrollmentModel> Enrollments { get; set; }
        public virtual ICollection<InstructorModel> Instructors { get; set; }
    }
}