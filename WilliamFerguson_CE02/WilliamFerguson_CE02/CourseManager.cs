using System;
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
        public static int age = 0;


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
                switch(_selection)
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
        }


        public static void AddStudents() { }
        public static void Display() { }

        public static bool Exit()
        {
            bool isExit = true;
            return isExit;

        }
    }
}
