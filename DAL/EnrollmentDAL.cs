using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using Infra;
using MOD;
using System.Linq;

namespace DAL
{
    public class EnrollmentDAL
    {
        private CollegeManagementContext db = new CollegeManagementContext();
        
        public JsonResult GetListEnrollments()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var _enrollment = (from s in dc.Subjects join e in dc.Enrollments on s.Id equals e.SubjectId
                                    join st in dc.Students on e.StudentId equals st.Id
                                    select new
                                    {
                                        subjectId = s.Id,
                                        subjectName = s.Name,
                                        teacherId = s.TeacherId,
                                        courseId = s.CourseId,
                                        studentId = e.StudentId,
                                        studentName = st.Name,
                                        Grade = e.Grade,
                                        enrollmentId = e.Id
                                    }).ToList();

                return new JsonResult { Data = _enrollment, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public EnrollmentMOD Details(int? id)
        {

            EnrollmentMOD enrollmentModel = db.Enrollments.Find(id);

            return enrollmentModel;
        }

        public void Create(EnrollmentMOD enrollmentModel)
        {
            db.Enrollments.Add(enrollmentModel);
            db.SaveChanges();
        }

        public void Edit(EnrollmentMOD enrollmentModel)
        {
            db.Entry(enrollmentModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            EnrollmentMOD enrollmentModel = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollmentModel);
            db.SaveChanges();
        }
    }
}
