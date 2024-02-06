using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_exc
{

    //https://www.w3schools.com/cs/cs_properties.php

    class Person
    {
        private string _name; //fields private
        private int _age;
        private string _city;

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public string Name  //proprty can help to access to the field
        { 
            get { return _name; } //getter to get the value of the private field 
        
            set 
            {
                if (value.Length < 2 || value.Length > 100)
                {
                    throw new ArgumentException("Name must be between 2 and 100 characters");
                }
                _name = value; 
            }
        }
        public int Age 
        { 
            get { return _age; } 
            set 
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("age must be between 0 and 100");
                }
                _age = value; 
            }
        }

        public string City { 
            get { return _city; }
            set {
                if (value.Length < 2 || value.Length > 100)
                {
                    throw new ArgumentException("city must be between 2 and 100 chars");
                }
                _city = value; 
            }
        }


        public override string ToString()
        {
            //return base.ToString(); //like super
            return String.Format("{0} is {1} y/o and lives in {2}", _name, Age, City);
        }

    }
}
