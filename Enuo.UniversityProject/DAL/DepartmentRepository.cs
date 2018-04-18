using Enuo.Repository.EF6;
using Enuo.UniversityProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.DAL
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentModel> GetDepartments();
        void AddOrEditDepartment(DepartmentModel item);
        DepartmentModel GetDepartment(int id);
        bool RemoveDepartment(int id);
    }

    public class DepartmentRepository: EFRepository<DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext ctx) :base(ctx){ }

        public void AddOrEditDepartment(DepartmentModel item)
        {
            
            if (item.DepartmentID==0)
            {
                Insert(item);
            }
            else
            {
                Update(item);
            } 
        }

        public DepartmentModel GetDepartment(int id)
        {
            return Find(x=>x.DepartmentID==id);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {        
            return Query().ToList<DepartmentModel>();
        }

        public bool RemoveDepartment(int id)
        {
            bool result = false;
            DepartmentModel remove = GetDepartment(id);
            if (remove != null)
            {
                Delete(remove);
                result = true;
            }
            return result;
        }
    }
}