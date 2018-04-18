using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public class ApplicationInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SchoolInitializer.InitalizeDepartmentForEF(context);
            SchoolInitializer.InitalizeCourseForEF(context);
            //SchoolInitializer.InitalizeEnrollmentForEF(context);
            SchoolInitializer.InitalizeInstructorForEF(context);
            SchoolInitializer.InitalizeStudentForEF(context);
            base.Seed(context);
        }
    }
}