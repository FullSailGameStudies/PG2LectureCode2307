using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Person
    {
        public virtual void Eat(string food)
        {
            Console.WriteLine($"Time to eat some {food}. Nom nom nom.");
        }
    }
    public class Superhero : Person
    {
        //override the base version
        public override void Eat(string food)
        {
            //call the base version to EXTEND it here
            base.Eat(food);
            Console.WriteLine("Time to save the world now!");

            //if you don't call the base version,
            //you are fully overriding it
        }
    }
}
