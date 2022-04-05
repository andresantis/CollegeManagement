using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using collegeManagementMagniFinance.Data;
using MOD;

namespace collegeManagementMagniFinance.Controllers
{
    public class CourseController: Controller
    {
        private CollegeManagementContext _context = new CollegeManagementContext();
        private CourseBLL courseBLL = new CourseBLL();

        public ActionResult Index()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                dc.Courses.ToList();
            }
            return View();
        }

        public int GetNumberTeachersPercourse(int id)
        {
            var numberTeachersPercourse = courseBLL.GetNumberTeachersPercourse(id);
            return numberTeachersPercourse;
        }

        public int GetNumberOfStudentPercourse(int id)
        {
            var numberOfStudentPercourse = courseBLL.GetNumberOfStudentPercourse(id);
            return numberOfStudentPercourse;
        }

        public int GetavgGradesPerCourse(int id)
        {
            var avgGradesPerCourse = courseBLL.GetavgGradesPerCourse(id);
            return avgGradesPerCourse;
        }

        public JsonResult GetListCourses()
        {
            return courseBLL.GetListCourses();
            
            
        }

        public JsonResult GetCourseById(int id)
        {
            return courseBLL.GetCourseById(id);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CourseMOD courseModel)
        {
            if (ModelState.IsValid)
            {
                courseBLL.Create(courseModel);
                return RedirectToAction("Index");
            }

            return View(courseModel);
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
        public ActionResult Edit(CourseMOD courseModel)
        {
            if (ModelState.IsValid)
            {
                courseBLL.Edit(courseModel);
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            courseBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
