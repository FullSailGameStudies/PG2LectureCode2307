using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public static class Factory
    {
        public static Car MakeCar(string make, string model, int year)
        {
            return new Car(make, model, year);
        }
    }
}
