﻿using System;
namespace WilliamFerguson_CE02
{
    public class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher(string _name, int _age, string _address): base(_name, _age)
        {
            Address = _address;
        }
    }
}
