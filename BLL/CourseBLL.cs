using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DAL;
using MOD;

namespace BLL
{
    public class CourseBLL : Controller
    {   
        private CourseDAL courseDAL = new CourseDAL();

        public int GetNumberTeachersPercourse(int id)
        {
            int numberTeachersPercourse = courseDAL.GetNumberTeachersPercourse(id);
            return numberTeachersPercourse;
        }

        public int GetNumberOfStudentPercourse(int id)
        {
            int numberOfStudentPercourse = courseDAL.GetNumberOfStudentPercourse(id);
            return numberOfStudentPercourse;
        }
        public int GetavgGradesPerCourse(int id)
        {
            int avgGradesPerCourse = courseDAL.GetavgGradesPerCourse(id);
            return avgGradesPerCourse;
        }

        public JsonResult GetListCourses()
        {

            List<CourseMOD> _courses = courseDAL.GetListCourses();

                List<Object> obj = new List<Object>();
                for (int i = 0; i < _courses.Count; i++)
                {
                    var objT = new
                    {
                        courseId = _courses[i].Id,
                        courseName = _courses[i].Name,
                        numberTeachersPerCourse = GetNumberTeachersPercourse(_courses[i].Id),
                        numberOfStudentPerCourse = GetNumberOfStudentPercourse(_courses[i].Id),
                        avgGradesPerCourse = GetavgGradesPerCourse(_courses[i].Id)
                    };
                    obj.Add(objT);
                }

                return new JsonResult { Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCourseById(int id)
        {
            var _courses = courseDAL.GetCourseById(id);
            return new JsonResult { Data = new { _courses.Name, _courses.Id }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public void Create(CourseMOD courseModel)
        {
            courseDAL.Create(courseModel);
        }

        public void Edit(CourseMOD courseModel)
        {
            courseDAL.Edit(courseModel);
        }

        public void Delete(int id)
        {
            courseDAL.Delete(id);
        }
    }
}
