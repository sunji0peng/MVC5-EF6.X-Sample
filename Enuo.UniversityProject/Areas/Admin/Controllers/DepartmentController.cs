using Enuo.UniversityProject.Areas.Admin.Models;
using Enuo.UniversityProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Enuo.UniversityProject.BLL;
using System.Net;

namespace Enuo.UniversityProject.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository repository = new DepartmentRepository(ApplicationDbContext.Create());
        private SelectList PopulateInstructorDropDownList(object selectedInstructor = null)
        {
            var data = repository.GetDepartments().OrderBy(b => b.Name);
            var newSeletctList = new SelectList(data, "DepartmentID", "Name", selectedInstructor);
            return newSeletctList;
           
        }
        public ActionResult Index(int? page)
        {
            var data = repository.GetDepartments();
            int pageNumber = page ?? AppConst.DefaultPageNumber;
            return View(data.ToPagedList<DepartmentModel>(pageNumber, AppConst.DefaultPageSize));
        }

        // GET: Admin/Department
        public ActionResult Create()
        {
            ViewBag.InstructorID = PopulateInstructorDropDownList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                repository.AddOrEditDepartment(model);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.InstructorID = PopulateInstructorDropDownList(model.DepartmentID);
                return View(model);
            }      
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var editor = repository.GetDepartment(id.Value);
            if (editor == null) { return HttpNotFound(); }
            ViewBag.InstructorID = PopulateInstructorDropDownList(editor);
            return View(editor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentModel model)
        {

            if (ModelState.IsValid)
            {
                repository.AddOrEditDepartment(model);
                return RedirectToAction("Index");
            }
            PopulateInstructorDropDownList(model.DepartmentID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var department = repository.GetDepartment(id);
            repository.RemoveDepartment(id);
            return Json(department);
        }
    }
}