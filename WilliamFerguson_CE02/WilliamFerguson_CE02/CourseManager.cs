using System;
namespace WilliamFerguson_CE02
{
    public class CourseManager
    {
        private static int _selection; // for our menu choice
        public static bool endThisNow = false; // signal to end the program



        public CourseManager()
        {
            Init(); // gateway to our program
        }

        public static void Init()
        {
            
            Console.Clear(); // clear the screen
            while (!endThisNow)
            {
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
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Selection not recognized.");
                        break;
                }

                   

            }
            

        }

        public static void CreateCourse() { }
        public static void CreateTeacher() { }
        public static void AddStudents() { }
        public static void Display() { }
        public static void Exit() { }
    }
}
