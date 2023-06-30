using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    /*                    METHODS          
                                                               
                ╔══════╗ ╔═══╗ ╔══════════╗ ╔════════════════╗ 
                ║public║ ║int║ ║SomeMethod║ ║(int someParam) ║ 
                ╚══════╝ ╚═══╝ ╚══════════╝ ╚════════════════╝ 
                    │      │         │               │         
              ┌─────┘      │         └──┐            └───┐     
         ┌────▼────┐   ┌───▼───┐   ┌────▼───┐       ┌────▼────┐
         │ Access  │   │ Return│   │ Method │       │Parameter│
         │ modifier│   │ type  │   │  Name  │       │  list   │
         └─────────┘   └───────┘   └────────┘       └─────────┘


    
    ╔═══════════╗ 
    ║Return type║ Return type defines the type of the data being returned.
    ╚═══════════╝
    │
    │
    └── If NO data is returned, then use "void" for the return type.
    │    public void PrintSomething()
    │    {
    │        Console.WriteLine("Something");
    │    }
    │
    │
    └── If a method returns data, then the return type must match the type of the data being returned.
        public float GetMyGrade()
        {
            return 99.9F; //returning a float so set return type to float
        }

    ╔══════════╗ 
    ║Parameters║ Parameters define the data passed to the method.
    ╚══════════╝
    │
    │
    └── If NO data is passed to the method, leave the parenthesis empty. EX: ( )
    │    public void PrintSomething()
    │   {  }
    │
    │
    └── If passing data to the method, then define the variable the method will use to store the data.
        Parameters are just variables therefore parameters need 2 things: <type> <name>
        Example:
        public void PrintMyGrade(float myGrade)
        {
            Console.WriteLine($"My grade is {myGrade}");
        }

        

     */
    internal class Program
    {
        static void Main(string[] args)
        {


            /*   
                ╔═══════════════════════════════╗ 
                ║Parameters: optional parameters║
                ╚═══════════════════════════════╝ 
                
                Unless specified, parameters to a method are required.
                However, you can make parameters optional, meaning when calling the method, you aren't required to pass values for the optional parameters.

                REQUIREMENT:
                    - all optional parameters have to be at the end of the list of parameters
                    - in the list of parameters, assign a value to any parameter you want to be optional
            */
            string file = "highScores";
            string postfile = PostFix(file); //if you don't pass a value, the default value will be used for the optional parameter
            Console.WriteLine(postfile);
            postfile = PostFix(file, 5); //if a value is passed, it will be used for the optional parameter
            Console.WriteLine(postfile);


            /*
                CHALLENGE 1:

                    Write a method called BatTheme.
                    Add an optional parameter to determine how many "na" are printed. 
                    The default value should be 13.

                    If the calling code does not pass a value for the parameter, 
                        print "na na na na na na na na na na na na na Batman".
                    If a value is passed, print the number of "na" equal to the value.
                    EX: if 6 is passed, print "na na na na na na Batman"

            */
            List<string> names = new() { "Bob", "Steve", "Carl" };
            PrintNames(names.ToList());
            Console.WriteLine("----in Main------");
            foreach (var name in names)
            {
                ColorWriteLine(name);
                Console.WriteLine();
            }
            BatTheme();
            BatTheme(25);

            Console.ReadKey();
            BatTheme4Ever();

            /*
                CHALLENGE 2:

                ConsoleColor

                    Write a ColorWriteLine method to print a message with a foreground color in the console.
                    1) add a string message parameter AND an optional color parameter. 
                        Choose whatever default color you want.
                    2) in the method, set the foreground color to the optional parameter
                    3) print the message
                    4) reset the color
             
            */

        }

        private static void PrintNames(List<string> names)//pass by value (COPY)
        {
            Console.WriteLine("----in PrintNames------");
            names[0] = "Bruce";
            names[1] = "Alfred";
            names[2] = "Richard";
            foreach (var name in names)
            {
                ColorWriteLine(name);
                Console.WriteLine();
            }
        }

        static void ColorWriteLine(string message, ConsoleColor fore = ConsoleColor.DarkCyan,
            ConsoleColor back = ConsoleColor.Black)
        {
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.Write(message);
            Console.ResetColor();
        }

        static void BatTheme(int nas = 13)
        {
            Random randy = new Random();
            for (int i = 0; i < nas; i++)
            {
                ColorWriteLine("na ", (ConsoleColor)randy.Next(16));
            }
            Console.WriteLine("Batman!");
        }

        static void BatTheme4Ever()
        {
            Random randy = new Random();
            while (true)
            {
                Console.SetCursorPosition(randy.Next(Console.WindowWidth), randy.Next(Console.WindowHeight));
                if (randy.Next(1000) == 500)
                    ColorWriteLine("Batman ", (ConsoleColor)randy.Next(16), (ConsoleColor)randy.Next(16));
                else
                    ColorWriteLine("na ", (ConsoleColor)randy.Next(16));

            }
        }

        static string PostFix(string fileName, int postFixNumber = 1) //postFixNumber is optional
        {
            return fileName + postFixNumber;
        }
    }
}
