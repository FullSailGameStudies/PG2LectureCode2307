﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02
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
        static Random randy = new Random();
        static void Main(string[] args)
        {

            /*   
                ╔══════════════════════════════╗ 
                ║Parameters: Pass by Reference.║
                ╚══════════════════════════════╝ 
                Sends the variable itself to the method. The method parameter gives the variable a NEW name (i.e. an alias)
                  
                NOTE: if the method assigns a new value to the parameter, the variable used when calling the method will change too.
                    This is because the parameter is actually just a new name for the other variable.
            */
            string spider = "Spiderman";
            bool isEven = PostFix(ref spider);
            Console.WriteLine($"{spider}. Even? {isEven}");
            string bats = "Batman";
            isEven = PostFix(ref bats);

            /*
                CHALLENGE 1:

                    Write a method to create and fill a list of floats with grades.
                    1) pass it in a list variable by reference
                    2) add 10 grades to the list

            */
            List<float> grades = null;// new List<float>();
            GetGrades(ref grades);
            double grade = randy.NextDouble() * 100;

            //anonymous types
            //var anon = new { TheBest = "Batman" };
            PrintGrades(grades);
            Console.ReadKey();


            /*  
                ╔═══════════════════════════╗ 
                ║Parameters: Out Parameters.║
                ╚═══════════════════════════╝  
                  A special pass by reference parameter. 
                  DIFFERENCES:
                    the out parameter does NOT have to be initialized before sending to the method
                    the method MUST assign a value to the parameter before returning

            */
            ConsoleColor randoColor; //don't have to initialize it
            bool colorIsBlack = GetRandomColor(out randoColor);
            Console.BackgroundColor = randoColor;
            if (colorIsBlack)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello Gotham!");
            Console.ResetColor();
            Console.ReadKey();

            //while (true)
            //{
            //    Console.SetCursorPosition(randy.Next(Console.WindowWidth), randy.Next(Console.WindowHeight-1));

            //    colorIsBlack = GetRandomColor(out randoColor);
            //    Console.BackgroundColor = randoColor;
            //    Console.Write("Batman");
            //    Console.ResetColor();
            //}



            /*
                CHALLENGE 2:

                    Write a method to calculate the stats on a list of grades
                    1) create a method to calculate the min, max, and avg. 
                        pass in the list of grades.
                        use out parameters to pass this data back from the method.
                    3) print out the min, max, and avg
             
            */
            //GradeStats(grades, out float min, out float max, out float avg);
            (float min, float max, float avg) = GradeStats(grades);
            Console.WriteLine($"Min: {min:N2}\tMax: {max:N2}\tAverage: {avg:N2}");




            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Removing from a List  ]

                There are 2 main ways to remove from a list:
                1) bool Remove(item).  will remove the first one in the list that matches item. returns true if a match is found else removes false.
                2) RemoveAt(index). will remove the item from the list at the index

            */
            List<string> dc = new() { "Batman", "Wonder Woman", "Aquaman", "Aquaman", "Superman", "Aquaman" };
            bool found = dc.Remove("Aquaman");
            dc.RemoveAt(dc.Count - 1);//removes the last item

            /*
                CHALLENGE 3:

                    Using the list of grades you created, 
                    Remove all the failing grades (grades < 59.5).
                    Print the grades.
            */
            //for (int i = 0; i < grades.Count;)
            //{
            //    if (grades[i] < 59.5)
            //    {
            //        grades.RemoveAt(i);
            //        //grades.Remove(grades[i]);//less efficient
            //    }
            //    else
            //        i++;
            //}

            //reverse for loop
            for (int i = grades.Count - 1; i >= 0; i--)
            {
                if (grades[i] < 59.5)
                    grades.RemoveAt(i);
            }
            PrintGrades(grades);

        }
        private static void PrintGrades(List<float> grades)
        {
            Console.WriteLine("---PG2 Grades---");
            foreach (float studentgrade in grades)
            {
                //,7 - right-align in 7 spaces
                //:N2 - format as a number w/ 2 decimal places
                Console.WriteLine($"{studentgrade,7:N2}");
            }
        }

        private static (float,float,float) GradeStats(List<float> grades)
        {
            float min = grades.Min();
            float max = grades.Max();
            float avg = grades.Average();
            return (min,max,avg);//return a tuple
        }
        private static void GradeStats(List<float> grades, out float min, out float max, out float avg)
        {
            //min = grades.Min();
            //max = grades.Max();
            //avg = grades.Average();

            min = float.MaxValue;
            max = float.MinValue;
            avg = 0;
            foreach (float grade in grades)
            {
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
                avg += grade;
            }   
            avg /= grades.Count;            
        }

        private static void GetGrades(ref List<float> grades)
        {
            //create the list
            //loop 10 times
            //  create a random grade and add it to the list
            grades = new List<float>();
            for (int i = 0; i < 10; i++)
            {
                //create a random grade
                //float grade = (float)randy.NextDouble() * 100;
                //add it to the list
                grades.Add((float)randy.NextDouble() * 100);
            }
        }

        private static bool GetRandomColor(out ConsoleColor outColor)
        {
            //the method MUST initialize the outColor parameter
            outColor = (ConsoleColor)randy.Next(16);
            return outColor == ConsoleColor.Black;
        }

        static bool PostFix(ref string hero) //hero is now an alias to the variable used when calling PostFix. In this case, hero is an alias to the spider variable.
        {
            //spider = "Spiderman";
            int postFix = randy.Next(100);
            hero += $"-{postFix}"; //updating hero now also updates spider
            return postFix % 2 == 0; //isEven
        }
    }
}
