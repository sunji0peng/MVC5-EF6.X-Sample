using Enuo.Repository.EF6;
using Enuo.UniversityProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public interface IInstructorRepository
    {
        IEnumerable<InstructorModel> QueryItems();
    }
    public class InstructorRepository:EFRepository<InstructorModel>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext ctx) : base(ctx) { }

        public IEnumerable<InstructorModel> QueryItems()
        {
            return Query().ToList<InstructorModel>();
        }
    }
}