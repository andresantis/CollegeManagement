using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using DAL;
using MOD;
using Newtonsoft.Json;

namespace BLL
{
    public class SubjectBLL
    {
        private SubjectDAL subjectDAL = new SubjectDAL();

        public JsonResult GetCourseAndTeacher()
        {
            var result = subjectDAL.GetCourseAndTeacher();
            return result;  
        }


        public int getStudentCountPerSubject(int id)
        {
            var numberOfStudentPerSubject = subjectDAL.getStudentCountPerSubject(id);
            return numberOfStudentPerSubject;
        }
        public JsonResult GetOnlySubjects()
        {
            var obj = subjectDAL.GetOnlySubjects();
            return obj;
            
        }

        public JsonResult GetListSubjects()
        {
            var _subject = subjectDAL.GetListSubjects();

            return _subject;

        }

        public JsonResult GetSubjectById(int id)
        {
            var subject = subjectDAL.GetSubjectById(id);
            
            return subject;
            
        }

        public void Create(SubjectMOD subjectModel)
        {
            subjectDAL.Create(subjectModel);
        }

        public void Edit(SubjectMOD subjectModel)
        {
            subjectDAL.Edit(subjectModel);

        }

        public void Delete(int id)
        {
            subjectDAL.Delete(id);
        }

    }
}
