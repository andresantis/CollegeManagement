using collegeManagementMagniFinance.Models;
using MOD;
using System;
using System.Collections.Generic;

namespace collegeManagementMagniFinance.Data
{
    public class CollegeManagementInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollegeManagementContext>
    {
        protected override void Seed(CollegeManagementContext context)
        {
            var students = new List<StudentMOD>
            {
            new StudentMOD{Id = 1, Name = "André Pires", ResgisterNumber = "st123456789", Birthday = new DateTime(1999,07,24)},
            new StudentMOD{Id = 2, Name = "marco", ResgisterNumber = "st223456789", Birthday = new DateTime(1998, 10, 13)},
            new StudentMOD{Id = 3, Name = "Heitor", ResgisterNumber = "st323456789", Birthday = new DateTime(1998,06,07)},
            new StudentMOD{Id = 4, Name = "João", ResgisterNumber = "st423456789", Birthday = new DateTime(1999, 01, 11)}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<TeacherMOD>
            {
            new TeacherMOD{Id= 1234, Name = "José Silva", Birthday =  new DateTime(1970,03,16), Salary = 4569.97, ResgisterNumber= "t123456787"},
            new TeacherMOD{Id= 2234, Name = "Joana Carmo", Birthday =  new DateTime(1974,10,08), Salary = 4569.97, ResgisterNumber= "t123456788"},
            new TeacherMOD{Id= 3234, Name = "Luiz Santos", Birthday =  new DateTime(1969,04,11), Salary = 4569.97, ResgisterNumber= "t123456789"}
            };
            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var courses = new List<CourseMOD>
            {
            new CourseMOD{Id=1, Name = "Calculus"},
            new CourseMOD{Id=2,Name = "Economy"},
            new CourseMOD{Id=3,Name="Computer Science"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();


            var subjects = new List<SubjectMOD>
            {
            new SubjectMOD{TeacherId = 1, Id=1, Name= "C#", CourseId = 3},
            new SubjectMOD{TeacherId = 3, Id=2, Name= "math", CourseId = 1},
            new SubjectMOD{TeacherId = 2, Id=3, Name= "Microeconomy", CourseId = 2}
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var enrollments = new List<EnrollmentMOD>
            {
            new EnrollmentMOD{StudentId=1,SubjectId=2,Grade=7, Id= 1},
            new EnrollmentMOD{StudentId=1,SubjectId=1,Grade=10, Id= 2},
            new EnrollmentMOD{StudentId=1,SubjectId=3,Grade=8, Id= 3},
            new EnrollmentMOD{StudentId=2,SubjectId=1,Grade=8, Id= 1},
            new EnrollmentMOD{StudentId=2,SubjectId=2,Grade=5, Id= 2},
            new EnrollmentMOD{StudentId=2,SubjectId=3,Grade=4, Id= 3},
            new EnrollmentMOD{StudentId=3,SubjectId=1,Grade=3, Id= 1},
            new EnrollmentMOD{StudentId=4,SubjectId=1,Grade=5, Id= 1},
            new EnrollmentMOD{StudentId=4,SubjectId=2,Grade=5, Id= 2}
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}