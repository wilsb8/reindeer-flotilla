using System;
namespace WilliamFerguson_CE02
{
    public class Teacher : Person
    {
        public string[] Knowledge { get; set; }

        public Teacher(string _name, string _description, int _age, string[] _knowledge): base(_name, _description, _age)
        {
            Knowledge = _knowledge;
        }
    }
}
