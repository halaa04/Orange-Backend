using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int CalculateAverage(int n, int m, int s)
            {
                return (n + m + s) / 3;
            }
            int avg = CalculateAverage(2, 2, 2);
            Console.WriteLine(avg);
            ////////////////////////
            List<String> names = new List<String>();
            names.Add("hala"); names.Add("mariam"); names.Add("sarah");
            Console.WriteLine(names);
            names.Remove("sarah");
            ////////////////////////
            Dictionary<int, string> students = new Dictionary<int, string>();
            students.Add(1, "hello"); students.Add(2, "world");
            Console.WriteLine(students[2]);
            ///////////////////////
            int[] numbers = { 5, 10, 15, 20, 25, 30 };
            int[] num = numbers.Where(x => x > 15).ToArray();
            foreach (int n in num)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("/////");
            int[] num2 = numbers.Where(x => x % 2 == 0).ToArray();
            foreach (int n in num2)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("/////");
            int[] num3 = numbers.OrderBy(n => n).ToArray();
            foreach (int n in num3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("/////");
            int[] num4 = numbers.OrderByDescending(n => n).ToArray();
            foreach (int n in num4)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("/////");
            int num5 = numbers.FirstOrDefault(n => n > 10);
            Console.WriteLine(num5);
            ////////////////////////
            string[] names2 = { "Ahmad", "Ali", "Sara", "Mona", "Omar" };
            var name = names2.Where(n => n.StartsWith("A"));
            foreach (var n in name)
            {
                Console.WriteLine(n);
            }
            ////////////////////////
            void Hi()
            {
                Console.WriteLine("Welcome");
            }
            void PrintGreeting(string name)
            {
                Console.WriteLine("Hello, " + name + "!");
            }
            PrintGreeting("Ahmad");
            void Age(int age = 21)
            {
                Console.WriteLine("your age : " + age);
            }
            Age();
            int Sum(int a, int b)
            {
                return a + b;
            }
            Console.WriteLine(Sum(2, 3));
            Console.ReadLine();
        }
    }
}