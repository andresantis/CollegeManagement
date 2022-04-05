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
    public class EnrollmentController : Controller
    {
        private CollegeManagementContext _context = new CollegeManagementContext();
        private EnrollmentBLL enrollmentBLL = new EnrollmentBLL();

        public ActionResult Index()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                dc.Enrollments.ToList();
            }
            return View();
        }
        public JsonResult GetListEnrollments()
        {
            return enrollmentBLL.GetListEnrollments();
        }
        public JsonResult GetEnrollmentById(int id)
        {
            return enrollmentBLL.GetEnrollmentById(id);
        }

        public JsonResult GetStudentsAndSubjects()
        {
            var students = new StudentBLL().GetListStudents();
            var subjects = new SubjectBLL().GetOnlySubjects();
            return new JsonResult { Data = new { students = students.Data, subjects = subjects.Data} , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EnrollmentMOD enrollmentModel)
        {
            if (ModelState.IsValid)
            {
                enrollmentBLL.Create(enrollmentModel);
                return RedirectToAction("Index");
            }
            return View(enrollmentModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EnrollmentMOD enrollmentModel)
        {
            if (enrollmentModel != null)
            {
                enrollmentBLL.Edit(enrollmentModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            enrollmentBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
