using collegeManagementMagniFinance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MOD;

namespace collegeManagementMagniFinance.Data
{
    public class CollegeManagementContext: DbContext
    {
        public CollegeManagementContext() : base("CollegeManagementContext")
        {

        }
        public DbSet<StudentMOD> Students { get; set; }
        public DbSet<TeacherMOD> Teachers { get; set; }
        public DbSet<CourseMOD> Courses { get; set; }
        public DbSet<SubjectMOD> Subjects { get; set; }
        public DbSet<EnrollmentMOD> Enrollments { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}