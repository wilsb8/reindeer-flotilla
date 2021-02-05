using System;
namespace WilliamFerguson_CE02
{
    public class Course
    {
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public TTeacher Teacher { get; set; }
        public Student[] Students { get; set; }

        public Course(string _courseTitle, string _courseDescription, int _numberOfStudents)
        {
            CourseTitle = _courseTitle;
            CourseDescription = _courseDescription;
            Student = new Student[_numberOfStudents];
        }
    }
}
