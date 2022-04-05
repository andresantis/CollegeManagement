using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BLL;
using collegeManagementMagniFinance.Data;
using MOD;

namespace collegeManagementMagniFinance.Controllers
{
    class StudentPercourse
    {
        public int StundetPerCourse { get; set; }
        public int SubjectId { get; set; }
    }
    public class SubjectController : Controller
    {
        private CollegeManagementContext _context = new CollegeManagementContext();
        private SubjectBLL subjectBLL = new SubjectBLL();

        // GET: Subject
        public ActionResult Index()
        {
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                dc.Subjects.ToList();
            }
            return View();
        }

        public ActionResult AllSubjects()
        {
            return View();
        }
        public JsonResult GetCourseAndTeacher()
        {
            return subjectBLL.GetCourseAndTeacher();
        }


        public int getStudentCountPerSubject(int id) {
            
            return subjectBLL.getStudentCountPerSubject(id);
        }
        public JsonResult GetOnlySubjects()
        {
            return subjectBLL.GetOnlySubjects();
        }

        public JsonResult GetListSubjects()
        {
            return subjectBLL.GetListSubjects();
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

            }
            return subjectBLL.GetSubjectById(id);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SubjectMOD SubjectMOD)
        {
            if (ModelState.IsValid)
            {
                subjectBLL.Create(SubjectMOD);
                return RedirectToAction("Index");
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
        public HttpStatusCode Edit(SubjectMOD SubjectMOD)
        {
            if (SubjectMOD == null)
            {
                return HttpStatusCode.InternalServerError;
            }
            else
            {
                subjectBLL.Edit(SubjectMOD);
                return HttpStatusCode.OK;
            }
                

                
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            subjectBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
