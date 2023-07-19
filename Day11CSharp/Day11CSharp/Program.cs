//using System;

namespace Day11CSharp
{
    internal class Program
    {
        enum Powers
        {
            Money = 10,
            Strength,
            Swimming
        }
        static void Main(string[] args)
        {
            System.Console.Write("Hello World!\n");
            Powers myPower = Powers.Money;
            switch (myPower)
            {
                case Powers.Money:
                    break;
                case Powers.Strength:
                    break;
                case Powers.Swimming:
                    break;
                default:
                    break;
            }
        }
    }
}
