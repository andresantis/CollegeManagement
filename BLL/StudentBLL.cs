using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DAL;
using MOD;

namespace BLL
{
    public class StudentBLL
    {
        private StudentDAL studentDAL = new StudentDAL();

        public JsonResult GetGrades(int id)
        {
            var grades = studentDAL.GetGrades(id);
            return grades;
        }

        public JsonResult GetListStudents()
        {
            var students = studentDAL.GetListStudents();
            List<object> listObj = new List<object>();
            foreach (var student in students)
            {
                var grades = GetGrades(student.Id);
                var obj = new
                {
                    studentId = student.Id,
                    studentName = student.Name,
                    studentBirthday = student.Birthday,
                    studentResgisterNumber = student.ResgisterNumber,
                    grades = grades.Data
                };

                listObj.Add(obj);
            }

            return new JsonResult { Data = listObj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult GetStudentById(int id)
        {
            var _student = studentDAL.GetStudentById(id);
            return _student;
        }

        public void Create(StudentMOD studentModel)
        {
            studentDAL.Create(studentModel);
        }

        public void Edit(StudentMOD studentModel)
        {
            studentDAL.Edit(studentModel);
        }

        public void Delete(int id)
        {
            studentDAL.Delete(id);
        }
    }
}
