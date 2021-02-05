using System;
namespace WilliamFerguson_CE02
{
    public class Person
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }

        public Person(string _name, string _description, int _age)
        {
            Name = _name;
            Description = _description;
            Age = _age;
        }
    }
}
