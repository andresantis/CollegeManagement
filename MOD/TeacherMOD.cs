using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOD
{
    public class TeacherMOD
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Salary { get; set; }
        public string ResgisterNumber { get; set; }
    }
}