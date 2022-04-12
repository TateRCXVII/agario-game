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
