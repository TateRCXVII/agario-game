/// <summary> 
/// Author:    Tate Reynolds/Thatcher Geary
/// Partner:   each other
/// Date:      4/16/2022 
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Thatcher Geary - This work may not be copied for use in Academic Coursework. 
/// 
/// We, Thatcher Geary and Tate Reynolds, certify that I wrote this code from scratch and did not copy it in part or whole from  
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// File Contents 
/// This was an excercise for the class 
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TowardAgarioStepTwo
{

    internal class Student
    {
        [JsonInclude]
        public float _GPA;

        private string _name;
        private int _ID;

        public Student()
        {

        }

        public Student(float gpa, string name)
        {
            _GPA = gpa;
            _name = name;
            _ID = 1;
        }

        [JsonConstructor]
        public Student(float _GPA, string Name, int ID)
        {
            this._GPA = _GPA;
            _name = Name;
            _ID = ID;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
