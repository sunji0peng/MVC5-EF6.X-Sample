using Enuo.UniversityProject.Areas.Admin.Models;
using Enuo.UniversityProject.BLL;
using Enuo.UniversityProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace Enuo.UniversityProject.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {

        private ICourseRepository repository = new CourseRepository(ApplicationDbContext.Create());
        private IDepartmentRepository DepRep = new DepartmentRepository(ApplicationDbContext.Create());
        private SelectList PopulateDepartmentDropDownList(object selecteddepartment = null)
        {
            var data = DepRep.GetDepartments().OrderBy(b => b.Name);
            var newSeletctList = new SelectList(data, "DepartmentID", "Name", selecteddepartment);
            return newSeletctList;
        }

        // GET: Admin/Course
        public ActionResult Index(int? page)
        {
            var data = repository.QueryItems();
            int pageNumber = page ?? AppConst.DefaultPageNumber;
            return View(data.ToPagedList<CourseModel>(pageNumber,AppConst.DefaultPageSize));
        }

        public ActionResult Create()
        {
            ViewBag.DepartmentID = PopulateDepartmentDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                repository.AddOrEditItem(model);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DepartmentID = PopulateDepartmentDropDownList(model.DepartmentID);
                return View(model);
            }        
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseModel model)
        {

            if (ModelState.IsValid)
            {
                repository.AddOrEditItem(model);
                return RedirectToAction("Index");
            }
            PopulateDepartmentDropDownList(model.DepartmentID);
            return View(model);
        }
    }
}