using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infra;
using MOD;

namespace DAL
{
    public class StudentDAL
    {
        private CollegeManagementContext db = new CollegeManagementContext();

        public JsonResult GetGrades(int id)
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {

                var grades = (from b in dc.Enrollments
                              where b.StudentId == id
                              select b.Grade).ToList();

                return new JsonResult { Data = grades, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public List<StudentMOD> GetListStudents()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var students = dc.Students.ToList();
                return students;

            }

        }

        public JsonResult GetStudentById(int id)
        {
            StudentMOD _student = null;
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {

                _student = (from b in dc.Students
                            where b.Id == id
                            orderby b.Name
                            select b)
                   .Include(p => p.Enrollments)
                   .FirstOrDefault();
            }
            return new JsonResult { Data = _student, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public void Create(StudentMOD studentModel)
        {
            db.Students.Add(studentModel);
            db.SaveChanges();
        }

        public void Edit(StudentMOD studentModel)
        {
            db.Entry(studentModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            StudentMOD studentModel = db.Students.Find(id);
            db.Students.Remove(studentModel);
            db.SaveChanges();
        }
    }
}
