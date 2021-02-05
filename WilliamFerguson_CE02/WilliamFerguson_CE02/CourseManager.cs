using System;
namespace WilliamFerguson_CE02
{
    public class CourseManager
    {

        public CourseManager()
        {
            Init(); // gateway to our program
        }

        public static void Init()
        {
            Console.Clear(); // clear the screen
            Menu.Init(); // display our menu

        }

        public static void CreateCourse() { }
        public static void CreateTeacher() { }
        public static void AddStudents() { }
        public static void Display() { }
        public static void Exit() { }
    }
}
