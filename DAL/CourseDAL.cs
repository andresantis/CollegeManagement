using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Infra;
using MOD;

namespace DAL
{
    public class CourseDAL
    {
        private CollegeManagementContext db = new CollegeManagementContext();

        public int GetNumberTeachersPercourse(int id)
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var numberTeachersPercourse = dc.Database.SqlQuery<int>("select qtdTeacher = count(TeacherId) from SubjectMOD where CourseId=@id group by CourseId order by CourseId", new SqlParameter("@id", id)).FirstOrDefault();
                return numberTeachersPercourse;
            }
        }

        public int GetNumberOfStudentPercourse(int id)
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var numberOfStudentPercourse = dc.Database.SqlQuery<int>("select qtdStudent= count(StudentId) from EnrollmentMOD e inner join SubjectMOD s on s.Id = e.SubjectId where CourseId=@id group by CourseId order by CourseId", new SqlParameter("@id", id)).FirstOrDefault();
                return numberOfStudentPercourse;
            }
        }
        public int GetavgGradesPerCourse(int id)
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var avgGradesPerCourse = dc.Database.SqlQuery<int>("select AVG(grade) from CourseMOD c inner join SubjectMOD s on s.CourseId = c.Id inner join TeacherMOD t on t.Id = s.TeacherId inner join EnrollmentMOD e on e.SubjectId = s.Id where CourseId=@id group by c.Name, c.Id order by c.Id", new SqlParameter("@id", id)).FirstOrDefault();
                return avgGradesPerCourse;
            }
        }

        public List<CourseMOD> GetListCourses()
        {
            
            using(CollegeManagementContext dc = new CollegeManagementContext())
            {

                List<CourseMOD> _courses = dc.Courses.ToList();
                return _courses;
            }
            
        }

        public CourseMOD GetCourseById(int id)
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                var _courses = dc.Courses.Find(id);
                return _courses;
            }
        }

        public void Create(CourseMOD courseModel)
        {
            db.Courses.Add(courseModel);
            db.SaveChanges();
        }

        public void Edit(CourseMOD courseModel)
        {
            db.Entry(courseModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            CourseMOD courseModel = db.Courses.Find(id);
            db.Courses.Remove(courseModel);
            db.SaveChanges();
        }
    }
}
