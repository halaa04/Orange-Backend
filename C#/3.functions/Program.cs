using System;         

class Program         
{
    //1
    static int MinToSec(int minutes)
    {
        return minutes * 60;   
    }
    //2
    static int Plus1(int num)
    {
        return num + 1;
    }
    //3
    static int FirstNum(int[] numbers)
    { 
        return numbers[0]; 
    }
    //4
    static double TriangleArea(double baseLength, double height)
    {
        return (baseLength * height) / 2;
    }
    //5
    static int[] EvenNumberEvenIndex(int[] nums)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0 && nums[i] % 2 == 0)  
             result.Add(nums[i]);
        }
        return result.ToArray();
    }
    //6 
    static string[] EvenIndexOddLength(string[] strings)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < strings.Length; i++)
        {
            if (i % 2 == 0 && strings[i].Length % 2 != 0)  
             result.Add(strings[i]);
        }
        return result.ToArray();
    }
    //7
    static double[] PowerElementIndex(int[] nums)
    {
        double[] result = new double[nums.Length];

        for (int i = 0; i < nums.Length; i++)
           result[i] = Math.Pow(nums[i], i);  

        return result;
    }
    //8
    static int Multiplication2(int a, int b)
    {
        int result = 0;
        for (int i = 0; i < b; i++)
         result = result + a;  

        return result;
    }
    //9
    static int Muti2(int a, int b)
    {
        int result = 1;
        for (int i = a; i <= b; i++)
          result = result * i; 
        
        return result;
    }
    //10
    static double AveArray(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
          sum = sum + nums[i];  
        
        return (double)sum / nums.Length;  
    }
    ///////////////// function 2 ///////////////////
    

    static void Main(string[] args)   
    {
        Console.WriteLine(MinToSec(10));

        Console.WriteLine(Plus1(10));
        int[] num = { 10, 12, 23 };
        Console.WriteLine(FirstNum(num));
        
        Console.WriteLine(TriangleArea(2,4));
       
        int[] nums = { 5, 2, 2, 1, 8, 66, 55, 77, 34, 9, 55, 1 };
        int[] evenResult = EvenNumberEvenIndex(nums);
        Console.WriteLine(string.Join(", ", evenResult));

        string[] strings = { "alex", "mercer", "madrasa", "rashed2", "emad", "hala" };
        string[] stringResult = EvenIndexOddLength(strings);
        Console.WriteLine(string.Join(", ", stringResult));

        int[] nums2 = { 44, 5, 4, 3, 2, 10 };
        double[] powerResult = PowerElementIndex(nums2);
        Console.WriteLine(string.Join(", ", powerResult));

        Console.WriteLine(Multiplication2(3, 5));
        Console.ReadLine();

        int[] numsAve = { 1, 2, 3, 8, 9, 77 };
        Console.WriteLine(AveArray(numsAve));


    }
    
}
