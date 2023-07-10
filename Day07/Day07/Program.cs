using Day07CL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    /*                    CLASSESS          
                                                               
                ╔══════╗ ╔═════╗ ╔═════════╗ 
                ║public║ ║class║ ║SomeClass║
                ╚══════╝ ╚═════╝ ╚═════════╝ 
                    │      │         │            
              ┌─────┘      │         └──┐               
         ┌────▼────┐   ┌───▼───┐   ┌────▼───┐       
         │ Access  │   │Keyword│   │ Class  │       
         │ modifier│   │       │   │  Name  │       
         └─────────┘   └───────┘   └────────┘      

    FIELDS - the data of the class

    PROPERTIES - the gatekeepers of the fields

    CONSTRUCTORS - the initializer of the class

    METHODS - the behavior of the class (what the class can do)

    
        
    
        ╔══════════════════╗ 
        ║ ACCESS MODIFIERS ║ - determines who can see it
        ╚══════════════════╝
            public: EVERYONE can see it
            private: ONLY this class can see it  (default)
            protected: this class and all my descendent classes can see it


     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myRide = new Car("Ford", "GT", 2023);//created an INSTANCE of the Car class
            //myRide.Year = 1980;
            Console.WriteLine($"The year of my car is {myRide.Year}");

            /*
                CHALLENGE 1:

                    Create a Person class in Day07CL project.
                    Right-Click the Day07CL project and select "Add > Class..."
             
            */





            /*  
                ╔════════╗ 
                ║ FIELDS ║ - the data of the class
                ╚════════╝ 
                
                use _camelCasingNamingConvention to name your fields in a C# class
            
                CHALLENGE 2:
                    Add an age field to the Person class
            */







            /*  
                ╔════════════╗ 
                ║ PROPERTIES ║ - the gatekeeper (control access) of the fields
                ╚════════════╝ 
                
                use PascalCasingNamingConvention to name your Properties in a C# class

                Properties have a "get" and a "set".
            
                here is a full property
                public int X
                {
                    //same as...public int GetX() {return _x;}
                    get { return _x; }

                    //same as...public void SetX(int value) {_x = value;}
                    set
                    {
                        if (value >= 0 && value < Console.WindowWidth)
                            _x = value;
                    }//value is a keyword
                }

                here is an auto-property (no field or code for the get/set is needed)
                public ConsoleColor Color { get; private set; } = ConsoleColor.DarkCyan;

            
                CHALLENGE 3:
                    Add an Age property provide access to the _age field
                    Add an auto-property for Name
            */






            /*  
                ╔══════════════╗ 
                ║ CONSTRUCTORS ║ - the initializer of the class. Initialize the data of the class.
                ╚══════════════╝ 
                
                RULES FOR CONSTRUCTORS...
                1) cannot have any return type, not even void
                2) must have the same name as the class
                
                HINT: use the ctor code snippet to provide a default contructor

                EXAMPLE:
                public GameObject(int x, int y, ConsoleColor color)
                {
                    X = x;
                    Y = y;
                    Color = color;
                    _numberOfGameObjects++;
                }

            
                CHALLENGE 4:
                    Add a constructor to the Person class 
                    to initialize Age and Name
            */
            Person bruce = new Person("Bruce Wayne", 35);
            Person alfred = new Person("Alfred Pennyworth", 100);





            /*  
                ╔═════════╗ 
                ║ METHODS ║ - the behavior of the class (what it can do)
                ╚═════════╝ 
                
                non-static methods can access the fields/properties/methods of the class
                static methods can only access the static members of the class

                EXAMPLE:
                public virtual void DrawMe()
                {
                    Console.SetCursorPosition(X, Y);
                    Console.BackgroundColor = Color;
                    Console.Write(" ");
                }
                            
                CHALLENGE 5:
                    write an ItsMyBirthday method. increment age and print out a happy message.
            */

            //static method... ClassName.Method
            Car.CarReport();

            //non-static (instance) method... instanceVariable.Method
            myRide.WhatAmI();//myRide is passed in to the 'this' param

            Car yourCar = new Car("Ford", "Pinto", 1975);
            yourCar.WhatAmI();//yourCar is passed in to the 'this' param

            PG2Color color;
            color.r = 255;
            color.g = 0;
            color.b = 0;
            color.a = 255;

            /*                              
                CHALLENGE 6:
                    
            1) In the class library, create an enum called WeaponRarity
                Add the following to the enum: Common, Uncommon, Rare, Legendary
            2) Create a class called FantasyWeapon
                Add the following auto-properties:
                    Rarity (use the WeaponRarity as the type)
                    Level (an int)
                    MaxDamage (an int)
                    Cost (an int)
                Add the following method:
                    DoDamage. Should return an int. It should calculate the damage by multiplying max damage by a randomly picking number between 0-1.
                Add a constructor to FantasyWeapon that takes in parameters for rarity, level, maxDamage, cost.
                    Be sure to set the properties with the parameters of the constructor.
            3) In Main, create an instance of FantasyWeapon.
                Call DoDamage on the instance and print the damage.

            */
            FantasyWeapon sting = new(WeaponRarity.Legendary, 100, 1000, 100000);
            int damage = sting.DoDamage();
            Console.WriteLine($"You swing Sting and do {damage} damage to the rat.");
        }
    }
}
