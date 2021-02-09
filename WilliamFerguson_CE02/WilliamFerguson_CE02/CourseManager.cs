using System;

// CourseManager.cs
// Written by William A. Ferguson 020621.1429
// Gonna make a change here.

namespace WilliamFerguson_CE02
{
    public class CourseManager
    {
        private static int _selection; // for our menu choice
        public static bool endThisNow = false; // signal to end the program
        private static Course _course = null;
        private static Teacher _teacher = null;
        private static Student[] _students = null;
        public static int numberOfStudents = 0;
        public static int grade = 0;


        public CourseManager()
        {
            Init(); // gateway to our program
        }

        public static void Init()
        {


            while (!endThisNow)
            {
                Console.Clear(); // clear the screen
                Menu.Init(); // display our menu
                Console.Write("\nSelection: ");
                string choice = Console.ReadLine();
                _selection = Validation.Integer(choice);
                switch (_selection)
                {
                    case 1:
                        CreateCourse();
                        break;
                    case 2:
                        CreateTeacher();
                        break;
                    case 3:
                        AddStudents();
                        break;
                    case 4:
                        Display();
                        break;
                    case 5:
                        endThisNow = Exit();
                        break;
                    default:
                        Console.WriteLine("Selection not recognized.");
                        break;
                }

            }
            Console.Clear();
            Console.WriteLine("Program terminating."); // goodbye
            Environment.Exit(0);

        }

        public static void CreateCourse() // method to create a course for our course manager
        {
            Console.Clear();
            Console.Write("Course Name: ");
            var courseTitleName = Console.ReadLine();
            string ctn = Validation.MyString(courseTitleName);
            Console.Write("Course description: ");
            var courseDescription = Console.ReadLine();
            string cdes = Validation.MyString(courseDescription);

            _students = new Student[numberOfStudents];
            _course = new Course(ctn, cdes, numberOfStudents);

            if (_teacher != null)
            {
                _course.Teacher = _teacher;
                Console.WriteLine("Course has been added with " + _teacher.Name);
            }

            Console.WriteLine("Course has been successfully created/added.");
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();

        }


        public static void CreateTeacher() // method to create a teacher
        {
            Console.Clear();
            Console.Write("Instructor Name: ");
            var nameOfInstructor = Console.ReadLine();
            string noi = Validation.MyString(nameOfInstructor);
            Console.Write("Age: ");
            var instructorAge = Console.ReadLine();
            int ia = Validation.Integer(instructorAge);
            Console.Write("Address: ");
            var instructorAddress = Console.ReadLine();
            string iadd = Validation.MyString(instructorAddress);

            _teacher = new Teacher(noi, ia, iadd);
            if (_course != null)
            {
                _course.Teacher = _teacher;
                Console.WriteLine("Teacher has been added to " + _course.CourseTitle);
            }

            Console.WriteLine("Teacher successfully created/addded.");
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }

        public static void AddStudents() // Method to add students. Will let you add them one at a time to build up a list of students.
        {
            
            if (_course == null)
            {
                Console.WriteLine("You must add a course before you add a student to it");
            }
            else
            {
                Console.Clear();
                Console.Write("Student Name: ");
                var name = Console.ReadLine();
                string n = Validation.MyString(name);
                Console.Write("Age: ");
                var studentAge = Console.ReadLine();
                int sa = Validation.Integer(studentAge);
                Console.Write("Grade: ");
                var studentGrade = Console.ReadLine();
                int sg = Validation.Integer(studentGrade);
                Student student = new Student(n, sa, sg);
                Array.Resize(ref _students, _students.Length + 1); // Ugliest. Hack. Ever.
                _students[_students.Length - 1] = student; // Also Ugliest. Hack. Ever.
                _course.Student = _students;
                Console.WriteLine("Students added to course " + _course.CourseTitle);
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }



        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("Display Information");
            Console.WriteLine("========================");
            Console.Write("Course Title: ");
            Console.WriteLine(_course.CourseTitle);
            Console.Write("Course Description: ");
            Console.WriteLine(_course.CourseDescription);
            Console.WriteLine("Course Instructor: " + _course.Teacher.Name + "::" + _course.Teacher.Address + "::" + _course.Teacher.Age);
            Console.WriteLine("\r\nStudents In Course");
            Console.WriteLine("========================");
            for (var index = 0; index < _course.Student.Length; index++)
            {
                Console.WriteLine("Student " + (index + 1) + ":" + _course.Student[index].Name + "::" + _course.Student[index].Age + "::" + _course.Student[index].Grade);
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();

        }

        public static bool Exit()
        {
            bool isExit = true;
            return isExit;

        }

    }
}