using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Infra;
using MOD;

namespace DAL
{
    public class TeacherDAL
    {
        private CollegeManagementContext db = new CollegeManagementContext();

        public JsonResult GetListTeachers()
        {
            List<TeacherMOD> _teachers = null;
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                _teachers = dc.Teachers.ToList();
            }

            return new JsonResult { Data = _teachers, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetTeacherById(int id)
        {
            TeacherMOD _teacher = null;
            using (CollegeManagementContext dc = new CollegeManagementContext())
            {
                _teacher = dc.Teachers.Find(id);
            }
            return new JsonResult { Data = _teacher, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public void Create(TeacherMOD teacherModel)
        {
                db.Teachers.Add(teacherModel);
                db.SaveChanges();
        }

        public void Edit(TeacherMOD teacherModel)
        {
            db.Entry(teacherModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            TeacherMOD teacherModel = db.Teachers.Find(id);
            db.Teachers.Remove(teacherModel);
            db.SaveChanges();
        }
    }
}
