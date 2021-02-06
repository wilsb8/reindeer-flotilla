using System;

// Course.cs
// Written by William A. Ferguson 020621.1429

namespace WilliamFerguson_CE02
{
    public class Course
    {
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public Teacher Teacher { get; set; }
        public Student[] Student { get; set; }

        public Course(string _courseTitle, string _courseDescription, int _numberOfStudents)
        {
            CourseTitle = _courseTitle;
            CourseDescription = _courseDescription;
            Student = new Student[_numberOfStudents];
        }
    }
}
