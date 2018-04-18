using Enuo.Repository.EF6;
using Enuo.UniversityProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public interface ICourseRepository
    {
        IEnumerable<CourseModel> QueryItems();
        void AddOrEditItem(CourseModel item);
    }

    public class CourseRepository : EFRepository<CourseModel>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext ctx) : base(ctx) { }

        public IEnumerable<CourseModel> QueryItems()
        {
            return Query().ToList<CourseModel>();
        }

        public void AddOrEditItem(CourseModel item)
        {
            if (item.CourseID == 0)
            {
                Insert(item);
            }
            else { Update(item); }
        }
    }
}