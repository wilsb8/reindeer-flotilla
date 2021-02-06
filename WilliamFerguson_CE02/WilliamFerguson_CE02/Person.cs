using System;

// Person.cs
// Written by William A. Ferguson 020621.1429


namespace WilliamFerguson_CE02
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string _name, int _age)
        {
            Name = _name;
            Age = _age;
        }
    }
}
