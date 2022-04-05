using DAL;
using MOD;
using System.Web.Mvc;

namespace BLL
{
    public class EnrollmentBLL
    {
        private EnrollmentDAL enrollmentDAL = new EnrollmentDAL();

        // GET: Enrollment/Details/5
        public JsonResult GetListEnrollments()
        {

            return enrollmentDAL.GetListEnrollments();

        }

        public JsonResult GetEnrollmentById(int id)
        {
            var _enrollment = enrollmentDAL.Details(id);
            var _student = new StudentDAL().GetStudentById(_enrollment.StudentId);
            var _subject = new SubjectDAL().GetSubjectById(_enrollment.SubjectId);
            return new JsonResult { Data = new { _enrollment.Id, _enrollment.Grade, student = _student.Data, subject = _subject.Data}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public EnrollmentMOD Details(int? id)
        {

            return enrollmentDAL.Details(id);

        }

        public void Create(EnrollmentMOD enrollmentModel)
        {
            enrollmentDAL.Create(enrollmentModel);
        }

        public void Edit(EnrollmentMOD enrollmentModel)
        {
            enrollmentDAL.Edit(enrollmentModel);
        }

        public void Delete(int id)
        {
           enrollmentDAL.Delete(id);
        }
    }
}
