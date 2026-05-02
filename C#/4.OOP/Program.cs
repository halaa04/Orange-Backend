using System;

class Program
{
    public class Person
    {
        public string Name { get; set; }
        protected int age;

        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            age = age;
        }
        public void personInfo()
        {
            Console.WriteLine("The name is : " + Name + "the Age is :" + age);
        }

    }
    public class Student : Person
    {
        public string id { get; set; }
        public void studentinfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {age}");
        }

        public Student(string n, int a, string i)
        {
            Name = n;
            age = a;
            id = i;
        }
    }

    class Car
    {
        public int Year { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public string PalletNo { get; set; }
        public string Color { get; set; }
        public static bool Engine = false;
        public Car(int year, string type, double price, string model, string palletNo, string color)
        {
            this.Year = year;
            this.Type = type;
            this.Price = price;
            this.Model = model;
            this.PalletNo = palletNo;
            this.Color = color;
            Engine = false;
        }
        public bool StartEngine()
        {
            Engine = true;
            return Engine;
        }
        public bool StopEngine()
        {
            Engine = false;
            return Engine;
        }
        public void Print()
        {
            Console.WriteLine($"Car Details \n" +
               $"Year: {Year}\n" +
               $"Type: {Type}\n" +
               $"Price: ${Price}\n" +
               $"Pallet No: {PalletNo}\n" +
               $"Color: {Color}");
        }

        public class OverloadingMethod
        {
            public double Add(double num1, double num2)
            {

                return num1 + num2;
            }
            public double Add(double num1, double num2, double num3)
            {

                return num1 + num2 + num3;
            }
            public decimal Add(decimal num1, decimal num2, decimal num3, decimal num4)
            {
                return num1 + num2 + num3 + num4;
            }
        }

        internal abstract class Employee
        {
            public string employeeName;
            public Employee(string employeeName)
            {
                this.employeeName = employeeName;
            }

            public abstract decimal CalculateSalary();

        }
        class FullTimeEmployee : Employee
        {
            private decimal _monthlySalary;

            public FullTimeEmployee(string name, decimal monthlySalary) : base(name)
            {
                _monthlySalary = monthlySalary;
            }

            public override decimal CalculateSalary()
            {
                return _monthlySalary;
            }
        }

        class PartTimeEmployee : Employee
        {
            public decimal HourlyRate { get; set; }
            public int HoursWorked { get; set; }

            public PartTimeEmployee(string name, decimal hourlyRate, int hoursWorked) : base(name)
            {
                HourlyRate = hourlyRate;
                HoursWorked = hoursWorked;
            }

            public override decimal CalculateSalary()
            {
                return HourlyRate * HoursWorked;
            }
        }

        public class Animal
        {
            public virtual void Speak()
            {
                Console.WriteLine("this animal speak like this");
            }
            public virtual void MakeSound()
            {
                Console.WriteLine("this animal make sound like this");

            }

        }

        public class Dog : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("the dog speak Woof Woof");
            }
            public override void MakeSound()
            {
                Console.WriteLine("the dog make sound Woof Woof");

            }

        }
        public class Cat : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("the dog speak meow meow");
            }
            public override void MakeSound()
            {
                Console.WriteLine("the dog make sound meow meow");

            }
        }

        static void Main(string[] args)
    {
        Person person = new Person("hala", 22);
        Student student = new Student("mariam", 22, "111");

        student.studentinfo();
        person.personInfo();

            Car myCar = new Car(2024, "Electric Sedan", 45000.00, "Model 3", "ABC-1234", "Deep Blue");

            myCar.Print();



            myCar.StartEngine();
            myCar.StopEngine();
        }
}
