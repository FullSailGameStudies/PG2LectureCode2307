using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    //class definition
    public class Person
    {
        private int _age;//declaring the variable

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0 && value <= 120)
                    _age = value;
            }
        }
        public string Name { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

    }
}
