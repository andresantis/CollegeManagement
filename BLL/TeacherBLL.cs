using System.Web.Mvc;
using DAL;
using MOD;

namespace BLL
{
    public class TeacherBLL
    {
        private TeacherDAL teacherDAL = new TeacherDAL();

        public JsonResult GetListTeachers()
        {
            var _teachers = teacherDAL.GetListTeachers();

            return _teachers;
        }

        public JsonResult GetTeacherById(int id)
        {
            var _teacher = teacherDAL.GetTeacherById(id);
            return _teacher;
        }

        public void Create(TeacherMOD teacherModel)
        {
            teacherDAL.Create(teacherModel);
        }

        public void Edit(TeacherMOD teacherModel)
        {
            teacherDAL.Edit(teacherModel);
        }

        public void Delete(int id)
        {
            teacherDAL.Delete(id);
        }
    }
}
