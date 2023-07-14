namespace Day09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Gotham!");

            Calculator t1000 = new();
            int n1 = 5, n2 = 2;
            int sum = t1000.Sum(n1,n2);
            Console.WriteLine($"{n1} + {n2} = {sum}");

            List<int> nums = new() { 5, 4, 3, 2, 1, 100 };
            t1000.Average(nums);
            //open for extension, closed for modification
        }
    }

    /*  
        ╔═════════════╗ 
        ║ OVERLOADING ║ - polymorphism by changing parameters
        ╚═════════════╝ 

        You can overload a method in 3 ways:
        1) different types on the parameters
        2) different number of parameters
        3) different order of parameters


        CHALLENGE 1:
            Add a overload of the Sum method to sum 2 doubles
    */

    class Calculator
    {
        public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }
        public double Sum(double n1, double n2)
        {
            return n1 + n2;
        }
    }

    enum Color
    {
        Red, Black, Green, ForestGreen
    }

    static class Extensions
    {
        public static double Average(this Calculator t1000, List<int> ints)
        {
            return ints.Average();
        }
    }
}