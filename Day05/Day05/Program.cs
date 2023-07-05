using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;

namespace Day04
{
    internal class Program
    {
        enum Weapon
        {
            Sword, Axe, Spear, Mace
        }
        static void Main(string[] args)
        {
            /*
                ╔═════════╗ 
                ║Searching║
                ╚═════════╝ 
             
                There are 2 ways to search a list: linear search or binary search
             
                CHALLENGE 1:

                    Convert Linear Search algorithm into a method. 
                        The method should take 2 parameters: list of ints to search, int to search for.
                        The method should return -1 if NOT found or the index if found.
                     
                    The algorithm:
                        1) start at the beginning of the list
                        2) compare each item in the list to the search item
                        3) if found, return the index
                        4) if reach the end of the list, return -1 which means not found
                    
            */
            List<int> nums = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            nums.Add(20);
            int searchNumber = 10;
            int index = LinearSearch2(nums, searchNumber);
            if(index == -1)
                Console.WriteLine($"{searchNumber} was not found.");
            else //if(index >=0)
                Console.WriteLine($"{searchNumber} was found at index {index}.");
            Console.ReadKey();



            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 
                
                [  Creating a Dictionary  ]
                
                Dictionary<TKey, TValue>  - the TKey is a placeholder for the type of the keys. TValue is a placeholder for the type of the values.
                
                When you want to create a Dictionary variable, replace TKey with whatever type of data you want to use for the keys and
                replace TValue with the type you want to use for the values.

            
                [  Adding items to a Dictionary  ]

                There are 3 ways to add items to a Dictionary:
                1) on the initializer. 
                2) using the Add method. 
                3) using [key] = value
            */
            //type of the keys: string
            //type of the values: float
            Dictionary<string, float> menu = new Dictionary<string, float>()
            {
                //{key, value}
                {"Hamburger", 12.99F},
                {"Cheez Burger", 13.99F },
                //{"Cheez Burger", 13.99F }//causes an exception!
            };
            menu.Add("Tater Tots", 5.99F);
            //menu.Add("Tater Tots", 5.99F);//causes an exception!
            menu.TryAdd("Fries", 4.99F);
            menu.Add("Onion Rigs", 6.99F);
            menu["Organic Salad"] = 15.99F;
            menu["Organic Salad"] = 17.99F;//does NOT throw an exception. overwrites the value.
            menu["Soda"] = 2.99F;


            Dictionary<Weapon, int> backpack = new Dictionary<Weapon, int>();//will store the counts of each kind of weapon
            backpack = new Dictionary<Weapon, int>()
            {
                {Weapon.Sword, 5 }
            };
            backpack.Add(Weapon.Axe, 2);
            backpack[Weapon.Spear] = 1;

            /*
                CHALLENGE 2:

                    Create a Dictionary that stores names (string) and grades. 
                    Call the variable grades.
             
                CHALLENGE 3:

                    Add students and grades to your dictionary 
             
            */
            List<string> students = new() { "Aidan", "Ali", "Amy", "Brandon", "Destiny", "Ja'Spring", "Lariq", "MiqKya", "Shuzhao", "Keith", "Vi", "Marco", "Anthony", "Alexander", "Clayton", "David", "Kevin", "Jonathan", "Antonio", "Tommy", "Tristan", "Colin", "Chanaya", "Eldwin" };
            Dictionary<string, double> grades = new();
            Random rando = new();
            foreach (var student in students)
            {
                //grades.Add(student, rando.NextDouble() * 100);
                grades[student] = rando.NextDouble() * 100;
            }





            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Looping over a Dictionary  ]

                You should use a foreach loop when needing to loop over the entire dictionary.
               
            */
            foreach (KeyValuePair<Weapon,int> weaponCount in backpack)
                Console.WriteLine($"You have {weaponCount.Value} {weaponCount.Key}");

            Console.WriteLine("\n Welcome to Lebronald's ");
            foreach (KeyValuePair<string,float> menuItem in menu)
            {
                string name = menuItem.Key;
                float price = menuItem.Value;
                Console.WriteLine($"{price,7:C2} {name}");
            }
            Console.ReadKey();

            for (int i = 0; i < menu.Count; i++)
            {
                string menuName = menu.Keys.ElementAt(i);
                float menuPrice = menu[menuName];
            }



            /*
                CHALLENGE 4:

                    Loop over your grades dictionary and print each student name and grade.
             
            */
            PrintGrades(grades);





            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Checking for a key in a Dictionary  ]

                There are 2 ways to see if a key is in the dictionary:
                1) ContainsKey(key)
                2) TryGetValue(key, out value)
               
            */
            if (backpack.ContainsKey(Weapon.Axe))
                Console.WriteLine($"{Weapon.Axe} count: {backpack[Weapon.Axe]}");

            if(backpack.TryGetValue(Weapon.Spear, out int spearCount))
                Console.WriteLine($"{Weapon.Spear} count: {spearCount}");

            string itemName = "Chicken Nuggets";
            //float nuggetPrice = menu[itemName];//cause a key-not-found exception!
            bool isFound = menu.ContainsKey(itemName);
            if (isFound)
            {
                Console.WriteLine($"{itemName} is on the menu and costs {menu[itemName]:C2}");
            }
            isFound = menu.TryGetValue(itemName, out float itemPrice);
            if(isFound)
                Console.WriteLine($"{itemName} is on the menu and costs {itemPrice:C2}");

            /*
                CHALLENGE 5:

                    Using either of the 2 ways to check for a key, 
                        look for a specific student in the dictionary. 
                    If the student is found, print out the student's grade
                    else print out a message that the student was not found
             
            */
            do
            {
                Console.Write("Please enter student's name to lookup: ");
                string studentName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(studentName)) break;

                if(grades.TryGetValue(studentName, out double studentGrade))
                    Console.WriteLine($"{studentName}'s grade is {studentGrade:N2}");
                else
                    Console.WriteLine($"{studentName} is not in PG2 this month.");
            } while (true);







            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Updating a value for a key in a Dictionary  ]

                To update an exisiting value in the dictionary, use the [ ]
                
               
            */
            backpack[Weapon.Mace] = 0; //sell all maces

            menu[itemName] = 9.99F;
            menu[itemName] = 6.99F;//overwrite the value


            /*
                CHALLENGE 6:

                    Pick any student and curve the grade (add 5) 
                    that is stored in the grades dictionary
             
            */
        }

        private static void PrintGrades(Dictionary<string, double> grades)
        {
            Console.WriteLine("\n\n  PG2 Grades  ");
            foreach (var student in grades)
            {
                double grade = student.Value;
                string name = student.Key;
                Console.ForegroundColor = (grade < 59.5) ? ConsoleColor.Red :
                                          (grade < 69.5) ? ConsoleColor.DarkYellow :
                                          (grade < 79.5) ? ConsoleColor.Yellow :
                                          (grade < 89.5) ? ConsoleColor.Blue : 
                                                           ConsoleColor.Green;
                Console.Write($"{grade,7:N2} ");
                Console.ResetColor();
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        private static int LinearSearch(List<int> nums, int searchNumber)
        {
            int found = -1;
            //start at the beginning
            for (int index = 0; index < nums.Count; index++)
            {
                if (nums[index] == searchNumber)
                {
                    found = index;
                    break;
                }
            }
            return found;
        }
        private static int LinearSearch2(List<int> nums, int searchNumber)
        {
            int found = 0;
            while(found < nums.Count && nums[found] != searchNumber)
                found++;
            return (found==nums.Count) ? -1 : found; //ternary operator
        }
    }
}
