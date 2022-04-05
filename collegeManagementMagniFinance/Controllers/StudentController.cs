using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using collegeManagementMagniFinance.Data;
using MOD;
using BLL;

namespace collegeManagementMagniFinance.Controllers
{
    public class StudentController : Controller
    {
        private CollegeManagementContext _context = new CollegeManagementContext();
        private StudentBLL studentBLL = new StudentBLL();

        // GET: Student
        public ActionResult Index()
        {   
            return View();
        }

        public JsonResult GetGrades(int id)
        {
            return studentBLL.GetGrades(id);
        }

        public JsonResult GetListStudents()
        {
            return studentBLL.GetListStudents();
        }

        public JsonResult GetStudentById(int id)
        {
            return studentBLL.GetStudentById(id);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentMOD StudentMOD)
        {
            if (ModelState.IsValid)
            {
                studentBLL.Create(StudentMOD);
                return RedirectToAction("Index");
            }

            return View(StudentMOD);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Edit(StudentMOD StudentMOD)
        {
            if (ModelState.IsValid)
            {
                studentBLL.Edit(StudentMOD);
                return RedirectToAction("Index");
            }
            return View(StudentMOD);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
