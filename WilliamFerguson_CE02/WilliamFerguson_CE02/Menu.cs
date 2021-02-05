using System;
using System.Collections.Generic;

namespace WilliamFerguson_CE02
{
    public class Menu
    {
    
            // private member fields

            private static string _title = "Course Tracker"; // do this to pass to other methods
            private string _menuItem;

            public Menu(string menuItem)
            {
                _menuItem = menuItem; // store a string for our menu items
            }

            public static void Init()
            {
                List<Menu> items = new List<Menu>() // initiate our menu object with items.
            {
                new Menu("[1] Create Course"),
                new Menu("[2] Create Teacher"),
                new Menu("[3] Add Students"),
                new Menu("[4] Display"),
                new Menu("[5] Exit")

            };

                Display(items); // display menu

            }

            public static void Display(List<Menu> menuList)
            {
                Console.WriteLine("================================");
                Console.WriteLine("\t" + _title);
                Console.WriteLine("================================");

                foreach (var x in menuList)
                {
                    Console.WriteLine(x._menuItem); // this is how you iterate a list of objects.
                }
                Console.WriteLine();
            }
        }
}
