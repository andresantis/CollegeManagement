using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOD
{
    public class EnrollmentMOD
    {
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }

        [NotMapped]
        public SubjectMOD Subject { get; set; }
        
        [NotMapped]
        public StudentMOD Student { get; set; }
    }
}