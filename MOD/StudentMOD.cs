using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOD
{
    public class StudentMOD
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string ResgisterNumber { get; set; }
        public ICollection<EnrollmentMOD> Enrollments { get; set; }

    }
}