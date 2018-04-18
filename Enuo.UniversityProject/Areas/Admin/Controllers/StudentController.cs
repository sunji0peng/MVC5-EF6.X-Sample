using Enuo.UniversityProject.BLL;
using Enuo.UniversityProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Enuo.UniversityProject.Areas.Admin.Models;

namespace Enuo.UniversityProject.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repository = new StudentRepository(ApplicationDbContext.Create());
        // GET: Admin/Student
        public ActionResult Index(int? page)
        {
            var data = repository.QueryItems();
            int pageNumber = page ?? AppConst.DefaultPageNumber;
            return View(data.ToPagedList<StudentModel>(pageNumber,AppConst.DefaultPageSize));
        }
    }
}