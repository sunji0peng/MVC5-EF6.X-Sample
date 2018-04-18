using Enuo.UniversityProject.Areas.Admin.Models;
using Enuo.UniversityProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public class SchoolInitializer
    {
        internal static void InitalizeCourseForEF(ApplicationDbContext ctx)
        {
            var courses = new List<CourseModel>
            {
            new CourseModel{CourseID=1050,Title="Chemistry",Credits=3},
            new CourseModel{CourseID=4022,Title="Microeconomics",Credits=3},
            new CourseModel{CourseID=4041,Title="Macroeconomics",Credits=3},
            new CourseModel{CourseID=1045,Title="Calculus",Credits=4},
            new CourseModel{CourseID=3141,Title="Trigonometry",Credits=4},
            new CourseModel{CourseID=2021,Title="Composition",Credits=3},
            new CourseModel{CourseID=2042,Title="Literature",Credits=4}
            };
            courses.ForEach(s => ctx.Courses.Add(s));
            ctx.SaveChanges();       
        }

        internal static void InitalizeDepartmentForEF(ApplicationDbContext ctx)
        {
            var departments = new List<DepartmentModel>
            {
                new DepartmentModel {DepartmentID=1001,Name = "儒家", Budget = 350000, StartDate = DateTime.Parse("2007-09-01")},
                new DepartmentModel {DepartmentID=1002,Name = "兵家", Budget = 100000, StartDate = DateTime.Parse("2010-09-01")},
                new DepartmentModel {DepartmentID=1003,Name = "阴阳家",Budget = 350000, StartDate = DateTime.Parse("2007-09-01")},
                new DepartmentModel {DepartmentID=1004,Name = "医家",Budget = 100000, StartDate = DateTime.Parse("2017-09-01")},
                new DepartmentModel {DepartmentID=1005,Name = "农家",Budget = 85888, StartDate = DateTime.Parse("2005-09-01")},
                new DepartmentModel {DepartmentID=1006,Name = "道家",Budget = 35666, StartDate = DateTime.Parse("2015-09-01")},
                new DepartmentModel {DepartmentID=1007,Name = "法家",Budget = 77888, StartDate = DateTime.Parse("2025-09-15")},
                new DepartmentModel {DepartmentID=1008,Name = "墨家",Budget = 65333, StartDate = DateTime.Parse("2005-06-22")},
                new DepartmentModel {DepartmentID=1009,Name = "纵横家",Budget = 56000, StartDate = DateTime.Parse("2005-09-01")},
                new DepartmentModel {DepartmentID=1010,Name = "流沙",Budget = 87900, StartDate = DateTime.Parse("2035-09-01")},
                new DepartmentModel {DepartmentID=1011,Name = "罗网",Budget = 89890, StartDate = DateTime.Parse("2005-09-01")},
                new DepartmentModel {DepartmentID=1012,Name = "秦势力",Budget = 63201, StartDate = DateTime.Parse("2015-09-01")},
                new DepartmentModel {DepartmentID=1013,Name = "楚势力",Budget = 10023, StartDate = DateTime.Parse("2005-08-01")}
            };
            departments.ForEach(s => ctx.Departments.Add(s));
            ctx.SaveChanges();
        }
        internal static void InitalizeStudentForEF(ApplicationDbContext ctx)
        {
            var students = new List<StudentModel>
            {
                new StudentModel {FirstMidName = "徐",LastName = "夫子", BirthDay=new DateTime(1970,5,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("1995-03-11") },
                new StudentModel {FirstMidName = "班",LastName = "大师",BirthDay=new DateTime(1970,11,02),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2002-07-06") },
                new StudentModel {FirstMidName = "端",LastName = "木蓉",  BirthDay=new DateTime(1981,01,22), Sex=SexType.FeMale,EnrollmentDate = DateTime.Parse("1998-07-01")},
                new StudentModel {FirstMidName = "雪",LastName = "女",BirthDay=new DateTime(1973,11,23),Sex=SexType.FeMale,EnrollmentDate = DateTime.Parse("2001-01-15") },
                new StudentModel {FirstMidName = "荆",LastName = "天明",BirthDay=new DateTime(1970,12,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2004-02-12") },
                new StudentModel {FirstMidName = "高",LastName = "渐离",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "晓梦",LastName = "大师",  BirthDay=new DateTime(1971,09,22),Sex=SexType.FeMale,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "盖",LastName = "聂",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "赤",LastName = "练",  BirthDay=new DateTime(1971,09,22),Sex=SexType.FeMale,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "荀",LastName = "子",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "英",LastName = "布",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "东皇",LastName = "太一",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "胜",LastName = "七",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") },
                new StudentModel {FirstMidName = "韩",LastName = "非子",  BirthDay=new DateTime(1971,09,22),Sex=SexType.Male,EnrollmentDate = DateTime.Parse("2010-02-12") }
            };

            students.ForEach(s => ctx.Students.Add(s));
            ctx.SaveChanges();
        }
        internal static void InitalizeEnrollmentForEF(ApplicationDbContext ctx)
        {
            var enrollments = new List<EnrollmentModel>
            {
            new EnrollmentModel{StudentID=1,CourseID=1050,Grade=Grade.A},
            new EnrollmentModel{StudentID=1,CourseID=4022,Grade=Grade.C},
            new EnrollmentModel{StudentID=1,CourseID=4041,Grade=Grade.B},
            new EnrollmentModel{StudentID=2,CourseID=1045,Grade=Grade.B},
            new EnrollmentModel{StudentID=2,CourseID=3141,Grade=Grade.F},
            new EnrollmentModel{StudentID=2,CourseID=2021,Grade=Grade.F},
            new EnrollmentModel{StudentID=3,CourseID=1050},
            new EnrollmentModel{StudentID=4,CourseID=1050,},
            new EnrollmentModel{StudentID=4,CourseID=4022,Grade=Grade.F},
            new EnrollmentModel{StudentID=5,CourseID=4041,Grade=Grade.C},
            new EnrollmentModel{StudentID=6,CourseID=1045},
            new EnrollmentModel{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => ctx.Enrollments.Add(s));
            ctx.SaveChanges();
        }
        internal static void InitalizeInstructorForEF(ApplicationDbContext ctx)
        {
            var instructors = new List<InstructorModel>
            {
                new InstructorModel{FirstMidName="Carson",LastName="Alexander",BirthDay=new DateTime(1970,5,22),Sex=SexType.Male,HireDate=DateTime.Parse("2005-09-01")},
                new InstructorModel{FirstMidName="Meredith",LastName="Alonso",BirthDay=new DateTime(1970,6,22),Sex=SexType.FeMale,HireDate=DateTime.Parse("2002-09-01")},
                new InstructorModel{FirstMidName="Arturo",LastName="Anand",BirthDay=new DateTime(1970,5,22),Sex=SexType.Male,HireDate=DateTime.Parse("2003-09-01")},
                new InstructorModel{FirstMidName="Gytis",LastName="Barzdukas",BirthDay=new DateTime(1970,5,22),Sex=SexType.Male,HireDate=DateTime.Parse("2002-09-01")},
                new InstructorModel{FirstMidName="Yan",LastName="Li",BirthDay=new DateTime(1970,5,22),Sex=SexType.Male,HireDate=DateTime.Parse("2002-09-01")},
                new InstructorModel{FirstMidName="Peggy",LastName="Justice",BirthDay=new DateTime(1970,5,22),Sex=SexType.FeMale,HireDate=DateTime.Parse("2001-09-01")},
                new InstructorModel{FirstMidName="Laura",LastName="Norman",BirthDay=new DateTime(1970,5,22),Sex=SexType.Male,HireDate=DateTime.Parse("2003-09-01")},
                new InstructorModel{FirstMidName="Nino",LastName="Olivetto",BirthDay=new DateTime(1970,5,22),Sex=SexType.FeMale,HireDate=DateTime.Parse("2005-09-01")}
            };
            //if (ctx.Departments != null)
            //{
            //    instructors[0].DepartmentID = 1001;
            //    instructors[1].DepartmentID = 1010;
            //    instructors[2].DepartmentID = 1009;
            //    instructors[3].DepartmentID = 1008;
            //    instructors[4].DepartmentID = 1002;
            //    instructors[5].DepartmentID = 1011;
            //    instructors[6].DepartmentID = 1012;
            //    instructors[7].DepartmentID = 1001;
            //}
            //if (ctx.OfficeAssignments != null)
            //{
            //    instructors[0].OfficeID = "Office001";
            //    instructors[1].OfficeID = "Office001";
            //    instructors[2].OfficeID = "Office002";
            //    instructors[3].OfficeID = "Office002";
            //    instructors[4].OfficeID = "Office003";
            //    instructors[5].OfficeID = "Office003";
            //}
            //if (ctx.Courses != null)
            //{
            //    instructors[0].CourseID = 4022;
            //    instructors[1].CourseID = 1045;
            //    instructors[2].CourseID = 2044;
            //    instructors[3].CourseID = 4022;
            //    instructors[4].CourseID = 3141;
            //    instructors[5].CourseID = 2021;
            //}
            instructors.ForEach(s => ctx.Instructors.Add(s));
            ctx.SaveChanges();
        }
    }

}