using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age : ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Hello my name is " + name + " and I'm " + age + " years old");
        
        /////////////////////////////////////
       
        Console.Write("Enter a num : ");
        int num = Console.Read();
        if (num % 2 == 0)
        {
            Console.WriteLine("even");
        }
        else
        {
            Console.WriteLine("odd");
        }
        
        /////////////////////////////////////
        
        Console.Write("Enter a String : ");
        string str = Console.ReadLine();
        Console.WriteLine(str);
      
        ////////////////////////////////////
        
        Console.Write("Enter a num : ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num > 0)
        {
            Console.Write("positive ");
        }
        else if (num < 0)
        {
            Console.Write("negative ");
        }
        else if (num == 0)
        {
            Console.Write("Zero ");
        }
        
        /////////////////////////////////////
       
            Console.Write("Enter a year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        if (year % 4 == 0)
        {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
                Console.WriteLine(year + " is a Leap year");
            else
                Console.WriteLine(year + " is NOT a Leap year");
        }
        else
        {
            Console.WriteLine(year + " is a Leap year");
        }
        }
        else
        {
            Console.WriteLine(year + " is NOT a Leap year");
        }
      
        //////////////////////////////////////
      
        Console.Write("Enter student grade: ");
        int grade = Convert.ToInt32(Console.ReadLine());

        if (grade >= 90)
            Console.WriteLine("Excellent");
        else if (grade >= 80)
            Console.WriteLine("Very Good");
        else if (grade >= 70)
            Console.WriteLine("Good");
        else if (grade >= 60)
            Console.WriteLine("Acceptable");
        else if (grade >= 50)
            Console.WriteLine("Pass");
        else
            Console.WriteLine("Fail");
       
        ///////////////////////////////////
        
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 > num2)
            Console.WriteLine(num1 + " is the largest");
        else if (num2 > num1)
            Console.WriteLine(num2 + " is the largest");
        else
            Console.WriteLine("Both numbers are equal");
        
        //////////////////////////////////////
        
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (num % 5 == 0 && num % 3 == 0)
            Console.WriteLine(num + " is divisible by both 5 and 3");
        else if (num % 5 == 0)
            Console.WriteLine(num + " is divisible by 5 only");
        else if (num % 3 == 0)
            Console.WriteLine(num + " is divisible by 3 only");
        else
            Console.WriteLine(num + " is not divisible by 5 or 3");
        */
        ////////////////////////////////
        
        Console.Write("Enter a character: ");
        char ch = Convert.ToChar(Console.ReadLine());

        ch = char.ToLower(ch);  // handle uppercase input

        if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            Console.WriteLine(ch + " is a Vowel");
        else 
            Console.WriteLine(ch + " is a Consonant");
        
        //////////////////////////////////
        
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        if (age < 0)
            Console.WriteLine("Invalid age");
        else if (age <= 12)
            Console.WriteLine("Child");
        else if (age <= 17)
            Console.WriteLine("Teenager");
        else if (age <= 64)
            Console.WriteLine("Adult");
        else
            Console.WriteLine("Senior");
        
        //////////////////////////////////
        
        Console.Write("Enter a number (1-7): ");
        int day = Convert.ToInt32(Console.ReadLine());

        switch (day)
        {
            case 1:Console.WriteLine("Monday");
                break;
            case 2: Console.WriteLine("Tuesday");
                break;
            case 3: Console.WriteLine("Wednesday");
                break;
            case 4: Console.WriteLine("Thursday");
                break;
            case 5: Console.WriteLine("Friday");
                break;
            case 6: Console.WriteLine("Saturday");
                break;
            case 7: Console.WriteLine("Sunday");
                break;
            default:  Console.WriteLine("Invalid number, enter 1-7");
                break;
        }
        
        ///////////////////////////////
        
        Console.Write("Enter a number (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        switch (month)
        {
            case 1: Console.WriteLine("January"); break;
            case 2: Console.WriteLine("February"); break;
            case 3: Console.WriteLine("March"); break;
            case 4: Console.WriteLine("April"); break;
            case 5: Console.WriteLine("May"); break;
            case 6: Console.WriteLine("June"); break;
            case 7: Console.WriteLine("July"); break;
            case 8: Console.WriteLine("August"); break;
            case 9: Console.WriteLine("September"); break;
            case 10: Console.WriteLine("October"); break;
            case 11: Console.WriteLine("November"); break;
            case 12: Console.WriteLine("December"); break;
            default: Console.WriteLine("Invalid number, enter 1-12"); break;
        }
        */
        ////////////////////////////////////////
        
        Console.Write("Enter first number : ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter operator (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter second number : ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        switch (op)
        {
            case '+': Console.WriteLine("Result: " + (num1 + num2));
                break;
            case '-': Console.WriteLine("Result: " + (num1 - num2));
                break;
            case '*': Console.WriteLine("Result: " + (num1 * num2));
                break;
            case '/': if (num2 == 0)
                    Console.WriteLine("Error: cannot divide by zero");
                else
                    Console.WriteLine("Result: " + (num1 / num2));
                break;
            default: Console.WriteLine("Invalid operator");
                break;
        }
        
        ///////////////////////////////
       
        Console.Write("Enter your score (0-100): ");
        int score = Convert.ToInt32(Console.ReadLine());

        switch (score)
        {
            case int n when n >= 90 && n <= 100:
                Console.WriteLine("A — Excellent");
                break;
            case int n when n >= 80:
                Console.WriteLine("B — Very Good");
                break;
            case int n when n >= 70:
                Console.WriteLine("C — Good");
                break;
            case int n when n >= 60:
                Console.WriteLine("D — Acceptable");
                break;
            case int n when n >= 0:
                Console.WriteLine("F — Fail");
                break;
            default:
                Console.WriteLine("Invalid score, enter 0-100");
                break;
        }
        
        ////////////////////////////////
       
        Console.Write("Enter a number (1-3) ");
        int nuum = Convert.ToInt32(Console.ReadLine());

        switch (nuum )
        {
            case 1:
                Console.WriteLine("1 - hi ");
                break;
            case int n when n >= 80:
                Console.WriteLine("2 - hello ");
                break;
            case int n when n >= 70:
                Console.WriteLine("3 - world ");
                break;
            default:
                Console.WriteLine("Invalid num, enter (1-3)");
                break;
        
        //////////////////////////////////
        
        Console.Write("Enter a number (1-3) ");
        int numm = Convert.ToInt32(Console.ReadLine());
        switch (numm)
        {
            case '/':
                if (numm % 2 == 0)
                    Console.WriteLine("even");
                else
                    Console.WriteLine("odd");
                break;
        }
        
        ///////////////////////////////
      
        Console.Write("Enter your role (Admin, User, Guest): ");
        string role = Console.ReadLine().ToLower();

        switch (role)
        {
            case "admin": Console.WriteLine("Welcome Admin!");
               break;

            case "user": Console.WriteLine("Welcome User!");
                break;

            case "guest":Console.WriteLine("Welcome Guest!");
                break;

            default:
                Console.WriteLine("Unknown role, access denied");
                break;
        }
        
        //////////////////////
       
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("1- HELLO");
        Console.WriteLine("2- EVEN OR ODD ");
        Console.WriteLine("3- PRINT YOUR AGE ");

        int num2 = Convert.ToInt32(Console.ReadLine());
        switch (num)
            {
            case 1: Console.WriteLine("HELLO");
                break;
            case 2: Console.WriteLine("Enter a num");
                int num2 = Convert.ToInt32(Console.ReadLine());
                if (num2 % 2 == 0) Console.WriteLine("even");
                else Console.WriteLine("odd");
            case 3:
                Console.WriteLine("Goodbye!");
                break;

            }


    }
}