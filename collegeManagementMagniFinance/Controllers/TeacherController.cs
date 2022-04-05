using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using collegeManagementMagniFinance.Data;
using collegeManagementMagniFinance.Models;
using MOD;

namespace collegeManagementMagniFinance.Controllers
{
    public class TeacherController : Controller
    {

        private CollegeManagementContext _context = new CollegeManagementContext();
        private TeacherBLL teacherBLL = new TeacherBLL();
        // GET: Teacher
        public ActionResult Index()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                dc.Teachers.ToList();
            }
            return View();
        }

        public ActionResult getTeachersForSubjects()
        {
            return View();
        }

        public JsonResult GetListTeachers()
        {
            return teacherBLL.GetListTeachers();
        }

        public JsonResult GetTeacherById(int id)
        {
            return teacherBLL.GetTeacherById(id);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherMOD TeacherMOD)
        {
            if (ModelState.IsValid)
            {
                teacherBLL.Create(TeacherMOD);
            }

            return View();
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
        public ActionResult Edit(TeacherMOD TeacherMOD)
        {
            if (ModelState.IsValid)
            {
               teacherBLL.Edit(TeacherMOD);
            }
            return View(TeacherMOD);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            teacherBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
