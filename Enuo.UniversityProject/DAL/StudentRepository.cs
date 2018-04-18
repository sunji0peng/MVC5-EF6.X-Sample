using Enuo.Repository.EF6;
using Enuo.UniversityProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> QueryItems();
    }
    public class StudentRepository: EFRepository<StudentModel>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext ctx) : base(ctx) { }

        public IEnumerable<StudentModel> QueryItems()
        {
            return Query().ToList<StudentModel>();
        }
    }
}