using Enuo.UniversityProject.Areas.Admin.Models;
using Enuo.UniversityProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        #region Property
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EnrollmentModel> Enrollments { get; set; }
        public DbSet<InstructorModel> Instructors { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<OfficeAssignmentModel> OfficeAssignments { get; set; }
        #endregion

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DepartmentModel>().HasKey(k => k.DepartmentID).ToTable("Department", "dbo");
            modelBuilder.Entity<CourseModel>().HasKey(k => k.CourseID).ToTable("Course", "dbo");
            modelBuilder.Entity<CourseModel>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor", "dbo"));

            modelBuilder.Entity<InstructorModel>().HasKey(k => k.Id).ToTable("Instructor", "dbo");
            modelBuilder.Entity<StudentModel>().HasKey(k => k.Id).ToTable("Student", "dbo");
            modelBuilder.Entity<EnrollmentModel>().HasKey(k => k.EnrollmentID).ToTable("Enrollment", "dbo");
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}