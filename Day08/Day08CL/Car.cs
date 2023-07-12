using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Car
    {
        protected string _vin = "1234578";
        public Car(string make, string model, int year)
        {
            Console.WriteLine("Car Ctor");
            Make = make;
            Model = model;
            Year = year;
        }
        #region Properties

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; } 
        #endregion
    }

    //Truck inherits everything from Car
    public class Truck : Car   //Truck is-a Car
    {
        //call the base constructor to initialize the Car parts
        //call the constructor
        public Truck(int towing, int bedSize, bool isDualCab, string make, string model, int year) 
            : base(make,model,year)
        {
            Console.WriteLine("\tTruck Ctor");
            TowingCapacity = towing;
            BedSize = bedSize;
            DualCab = isDualCab;
            Console.WriteLine(_vin);
        }
        public int TowingCapacity { get; set; }
        public int BedSize { get; set; }
        public bool DualCab { get; set; }
    }
}
