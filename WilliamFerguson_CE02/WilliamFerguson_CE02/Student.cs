using System;

namespace WilliamFerguson_CE02
{
    public class Student : Person
    {
        public int Grade { get; set; }
        // Keyword base is used in constructors (in constructor initializers).
        // A derived class (Student) constructor is required to call the constructor from its base class (Person).
        public Student(string _name, int _age, int _grade) : base(_name, _age)
        {
            Grade = _grade;
        }
    }
}
