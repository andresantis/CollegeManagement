using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOD
{
    public class SubjectMOD
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int CourseId{ get; set; }
        public CourseMOD Course { get; set; }
        public TeacherMOD Teacher { get; set; }
        public List<StudentMOD> Students { get; set; }
        public ICollection<EnrollmentMOD> Enrollments { get; set; }
    }
}