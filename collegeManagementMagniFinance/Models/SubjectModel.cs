using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collegeManagementMagniFinance.Models
{
    public class SubjectModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int CourseId{ get; set; }
        public CourseModel Course { get; set; }
        public TeacherModel Teacher { get; set; }
        public List<StudentModel> Students { get; set; }
        public ICollection<EnrollmentModel> Enrollments { get; set; }
    }
}