using System;
using System.Collections.Generic;

namespace Day01
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
    
            Vocabulary:
        
                  method (or function): https://www.w3schools.com/cs/cs_methods.php
                      a block of code that can be referenced by name to run the code it contains.

                  parameter: https://www.w3schools.com/cs/cs_method_parameters.php
                      a variable in the method definition.The list of parameters appear between the ( ) in a method header.

                  arguments:
                      when a method is called, arguments are the data you pass into the method's parameters
        
                  return type: https://www.w3schools.com/cs/cs_method_parameters_return.php
                      the value returned when a method finishes.
                      A return type must be specified on a method.
                      If no data is returned, use void.
    
        
                  List<T>: https://www.tutorialsteacher.com/csharp/csharp-list#:~:text=C%23%20-%20List%3CT%3E%201%20List%3CT%3E%20Characteristics%20List%3CT%3E%20equivalent,8%20Check%20Elements%20in%20List%20...%20More%20items
                    a collection of strongly typed objects that can be accessed by index. Indexes start at 0.



             Lecture videos:
                  METHODS LECTURE:
                  https://fullsailedu-my.sharepoint.com/:v:/g/personal/ggirod_fullsail_com/EW0hLKhQiBdFjOGq1WG6oRoB9TTQWJd1L9ic6VRiEYwgdg?e=J7uZXt
                  Chapters: Method Basics through Method Examples

                  LIST LECTURE:
                  https://fullsailedu-my.sharepoint.com/:v:/g/personal/ggirod_fullsail_com/ERG1iZHKJgFIoj6W8dhxPPgBIIY-Ot1b6Ueh-50Ggfcikg?e=goT9d6
                  Chapters: Array Basics through Looping Examples.

     */
    internal class Program
    {
        static int Add(int n1, int n2)
        {
            //int n1 = 5, n2 = 2;
            int sum = n1 + n2;
            //Console.WriteLine(sum);
            return sum;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int num1 = 13, num2 = 407;
            int result = Add(num1, num2);
            //$ - interpolated string
            Console.WriteLine($"{num1} + {num2} = {result}");
            result = Add(5, 2);
            /*
              Calling a method
                use the methods name.
                1) if the method needs data (i.e. has parameters), you must pass data to the method that matches the parameter types
                2) if the method returns data, it is usually best to store that data in a variable on the line where you call the method.
             
            */

            /*
                ╔══════════════════════════╗ 
                ║Parameters: Pass by Value.║
                ╚══════════════════════════╝ 
             
                Copies the value to a new variable in the method.
                
                For example, the AddOne method has a parameter called localNumber. localNumber is a variable that is local ONLY to the method.
                The value of the variable in main, number, is COPIED to the variable in AddOne, localNumber.
              
            */
            int number = 5;
            int plusOne = AddOne(number);


            /*
                CHALLENGE 1:

                    Add an IsEven method to the calculator class (see below).
                    It should take 1 parameter and return a bool.

                    Call the method on the t1000 calculator instance and print the results.

            */
            Calculator t800 = new Calculator();//creating an instance of Calculator
            Calculator.WhoAmI();//b/c it's static, I use the class name to access it.
            result = t800.Sum(num1, num2);
            bool isEven = t800.IsEven(num2);
            Console.WriteLine($"Is {num2} even? {isEven}");



            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 
                
                [  Creating a List  ]
                
                List<T>  - the T is a placeholder for a type. It is a "Generic Type Parameter" to the class.
                
                When you want to create a List variable, replace T with whatever type of data you want to store in the List.
            */
            List<string> names = new List<string>(); //this list stores strings and only strings.







            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Adding items to a List  ]

                There are 2 ways to add items to a list:
                1) on the initializer. 
                2) using the Add method. 
            */
            List<char> letters = new List<char>() { 'B', 'a', 't', 'm', 'a', 'n' };
            letters.Add('!');


            string[] best = new string[] { "Batman", "Bruce", "NOT Aquaman" };
            string name = best[1];//0-based indexes
            Console.WriteLine(name);
            Console.WriteLine("----BEST NAMES---");
            for (int i = 0; i < best.Length; i++)
            {
                Console.WriteLine(best[i]);
            }
            Console.WriteLine("----BEST NAMES---");
            best[2] = "The Greatest Detective";
            foreach (var bestName in best)
            {
                Console.WriteLine(bestName);
            }

            List<string> bestnames;//null
            bestnames = new List<string>();// {"Batman"};
            Info(bestnames);//Count: 0   Capacity: 0
            bestnames.Add("Bruce Wayne");
            Info(bestnames);//Count: 1   Capacity: 4
            //bestnames[2] = "Steve";
            bestnames[0] = "Mr. Wayne";

            bestnames.Add("Wonder Woman");
            bestnames.Add("Superman");
            bestnames.Add("The Joker");
            bestnames.Add("Bane");
            Info(bestnames);//Count: 5   Capacity: 8? 20?
            bestnames.Add("Flash");
            bestnames.Add("Riddler");
            bestnames.Add("Penguin");
            bestnames.Add("Two-Face");
            bestnames.Add("Poison Ivy");
            Info(bestnames);//Count: 10   Capacity: 14? 13?

            /*
                CHALLENGE 2:

                    Create a list that stores floats. Call the variable grades.
                    Add a few grades to the grades list.
             
            */
            Random rando = new Random();
            List<float> grades = new List<float>();
            grades.Add((float)rando.NextDouble() * 100);
            grades.Add((float)rando.NextDouble() * 100);
            grades.Add((float)rando.NextDouble() * 100);
            grades.Add((float)rando.NextDouble() * 100);
            grades.Add((float)rando.NextDouble() * 100);
            grades.Add((float)rando.NextDouble() * 100);






            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Looping over a List  ]

                You can loop over a list with a for loop or a foreach loop.
                1) for loop. use the Count property in the for condition.
                2) foreach loop
            */
            for (int i = 0; i < letters.Count; i++)
                Console.Write($" {letters[i]}");

            foreach (var letter in letters)
                Console.Write($" {letter}");


            /*
                CHALLENGE 3:

                    loop over the grades list and print out each grade

            */
            Console.WriteLine("\n-----GRADES--------");
            for (int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine(grades[i]);
            }
            Console.WriteLine("\n---GRADES---");
            foreach (var grade in grades)
            {
                //ternary operator
                Console.ForegroundColor = (grade < 59.5) ? ConsoleColor.Red :
                                          (grade < 69.5) ? ConsoleColor.DarkYellow :
                                          (grade < 79.5) ? ConsoleColor.Yellow :
                                          (grade < 89.5) ? ConsoleColor.Blue :
                                          ConsoleColor.Green;
                //,7 means right-align in 7 spaces
                //:N2 means format as a number with 2 decimal places
                Console.WriteLine($"{grade,7:N2}");
            }
            Console.ResetColor();





            /*
                BOSS CHALLENGE:

                    1) Fix the Average method of the calculator class to calculate the average of the list parameter.
                    2) Call the Average method on the t1000 variable and pass your grades list to the method.
                    3) print the average that is returned.
             
            */


            Console.ReadKey(true);
        }


        private static void Info(List<string> names)
        {
            //Count: # of items added to the list
            //Capacity: size (length) of the internal array
            Console.WriteLine($"Count: {names.Count}\tCapacity: {names.Capacity}");
        }

        private static int AddOne(int localNumber)
        {
            return localNumber + 1;
        }


    }

    class Calculator
    {
        public bool IsEven(int someNumber)
        {
            return someNumber % 2 == 0;
        }
        public static void WhoAmI()
        {
            Console.WriteLine("The T800. I am a cybernetic organism.");
        }
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }


        public float Average(List<float> numbers)
        {
            float avg = 0F;

            //loop over the numbers and calculate the average

            return avg;
        }
    }
}
