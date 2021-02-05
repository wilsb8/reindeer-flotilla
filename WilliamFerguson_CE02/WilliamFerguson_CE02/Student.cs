using System;
namespace WilliamFerguson_CE02
{
    public class Student : Person
    {
        public int Grade { get; set; }
        public Student(string _name, string _description, int _age, int _grade) : base(_name, _description, _age)
        {
            Grade = _grade;
        }
    }
}
