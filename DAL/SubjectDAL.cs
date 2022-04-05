using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Infra;
using MOD;

namespace DAL
{
    public class SubjectDAL
    {
        private CollegeManagementContext db = new CollegeManagementContext();

        public JsonResult GetCourseAndTeacher()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var Teachers = dc.Teachers.ToList();
                var Courses = dc.Courses.ToList();
                return new JsonResult { Data = new { Teachers, Courses }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        public int getStudentCountPerSubject(int id)
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var numberOfStudentPerSubject = dc.Database.SqlQuery<int>("select count(StudentId) from EnrollmentMOD e inner join SubjectMOD s on s.Id = e.SubjectId where SubjectId = @id group by e.SubjectId order by e.SubjectId", new SqlParameter("@id", id)).FirstOrDefault();
                return numberOfStudentPerSubject;
            }
        }
        public JsonResult GetOnlySubjects()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var obj = dc.Subjects.ToList();
                return new JsonResult { Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetListSubjects()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var _subjects = (from s in dc.Subjects
                                 join t in dc.Teachers on s.TeacherId equals t.Id
                                 join c in dc.Courses on s.CourseId equals c.Id
                                 join e in dc.Enrollments on s.Id equals e.SubjectId
                                 join st in dc.Students on e.StudentId equals st.Id
                                 select new
                                 {
                                     subjectId = s.Id,
                                     subjectName = s.Name,
                                     teacherId = s.TeacherId,
                                     courseId = s.CourseId,
                                     studentId = e.StudentId,
                                     Grade = e.Grade,
                                     teacherName = t.Name,
                                     teacherSalary = t.Salary,
                                     t.Birthday
                                 }).ToList();



                List<Object> obj = new List<Object>();
                for (int i = 0; i < _subjects.Count; i++)
                {
                    var objT = new
                    {
                        subjectId = _subjects[i].subjectId,
                        subjectName = _subjects[i].subjectName,
                        teacherId = _subjects[i].teacherId,
                        teacherName = _subjects[i].teacherName,
                        teacherBirthday = _subjects[i].Birthday,
                        teacherSalary = _subjects[i].teacherSalary,
                        numberOfStudentPerCourse = getStudentCountPerSubject(_subjects[i].subjectId),
                        grade = _subjects[i].Grade
                    };
                    obj.Add(objT);
                }

                return new JsonResult { Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult GetSubjectById(int id)
        {
            SubjectMOD _subject = null;
            List<TeacherMOD> _teachers = null;
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                _subject = dc.Subjects.Find(id);
                _teachers = dc.Teachers.ToList();
                var itemSelected = dc.Teachers.Find(_subject.TeacherId);

                return new JsonResult { Data = new { _subject.Name, _subject.Id, _subject.TeacherId, _subject.CourseId, _teachers, itemSelected }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public void Create(SubjectMOD subjectModel)
        {
                db.Subjects.Add(subjectModel);
                db.SaveChanges();
        }

        public void Edit(SubjectMOD subjectModel)
        {
            db.Entry(subjectModel).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            SubjectMOD subjectModel = db.Subjects.Find(id);
            db.Subjects.Remove(subjectModel);
            db.SaveChanges();
        }

    }
}
