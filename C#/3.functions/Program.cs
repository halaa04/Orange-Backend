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
    ///////////////// function 3 ///////////////////
    //1
    static Func<int, int> Add(int a)
    {
        return delegate (int x)
        {
            return a + x;
        };
    
    }
    //2
    static string RemoveLeadingTrailing (string s)
    {
        decimal number = decimal.Parse(s);
        return number.ToString("G29");
    }
    //3
    static int SecNum(int[] nums)
    {
        Array.Sort(nums);
        return nums[nums.Length - 2];
    }
    //4
    static bool IsRepdigit (int n)
    {
        if (n < 0) return false;
        string s=  n.ToString();
        foreach (char c in s)
        {
            if (c != s[0]) return false;
        }
        return true;
    }
    //5
    static string ReverseWords(string s)
    {
        string[] words = s.Trim().Split(' ');  
        Array.Reverse(words);                 
        return string.Join(" ", words);      
    }
    //6
    static string SevenBoom(int[] nums)
    {
        foreach (int num in nums)
        {
            string s = num.ToString();    
            foreach (char c in s)
              if (c == '7') return "Boom!";  
        }
        return "there is no 7 in the array";  
    }
    //7
    static string InsertWhitespace(string s)
    {
        string result = "";
        for (int i = 0; i < s.Length; i++)
        {
            result += s[i];                          

            if (i + 1 < s.Length &&
                char.IsLower(s[i]) &&                 
                char.IsUpper(s[i + 1]))               
                result += " ";                        
            
        }
        return result;
    }
    //8 
    static int CountTrue(bool[] arr)
    {
        int count = 0;
        foreach (bool b in arr)
            if (b == true) count++;
        return count;
    }
    //9
    static string CapToFront(string s)
    {
        string caps = "";
        string lower = "";
        foreach (char c in s)
        {
            if (char.IsUpper(c)) caps += c;  
            else lower += c;  
        }
        return caps + lower;  
    }
    //10
    static bool MatchLastItem(object[] arr)
    {
        string last = arr[arr.Length - 1].ToString();  
        string rest = "";
        for (int i = 0; i < arr.Length - 1; i++)
            rest += arr[i].ToString();                 
        return last == rest;
    }
    //11
    static int FindNaN(double[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            if (double.IsNaN(arr[i])) return i;  
        return -1;                               
    }
    //12
    static object[] RemoveDups(object[] arr)
    {
        List<object> result = new List<object>();
        foreach (object item in arr)
            if (!result.Contains(item))   
                result.Add(item);
        return result.ToArray();
    }
    //13
    static string ConvertTime(string time)
    {
        int hours = int.Parse(time.Substring(0, 2));
        string mins = time.Substring(3, 2);
        string secs = time.Substring(6, 2);
        string ampm = time.Substring(8, 2);

        if (ampm == "PM" && hours != 12) hours += 12;  // PM → add 12
        if (ampm == "AM" && hours == 12) hours = 0;  // 12AM → 0

        return hours.ToString("D2") + ":" + mins + ":" + secs;
    }
    //14
    static string RemoveLastVowel(string sentence)
    {
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string w = words[i];
            for (int j = w.Length - 1; j >= 0; j--)  
            {
                if ("aeiouAEIOU".Contains(w[j]))      
                {
                    words[i] = w.Remove(j, 1);         
                    break;
                }

            }
        }
        return string.Join(" ", words);
    }
    //15
    static double SumOfCubes(int[] nums)
    {
        double sum = 0;
        foreach (int n in nums)
            sum += Math.Pow(n, 3);   
        return sum;
    }


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

        int[] numsAve = { 1, 2, 3, 8, 9, 77 };
        Console.WriteLine(AveArray(numsAve));

        ///////////////////////////////////////////////
        
        Func<int, int> add10 = Add(10);
        Console.WriteLine(add10(20));

        Console.WriteLine(RemoveLeadingTrailing(0223.00);

        Console.WriteLine(SecNum(numsAve));

        Console.WriteLine(IsRepdigit(66));

        Console.WriteLine(ReverseWords("hello  world! "));

        Console.WriteLine(InsertWhitespace("HelloWorld"));

        bool[] bools = { true, false, false, true, false };
        Console.WriteLine(CountTrue(bools));                        

     
        Console.WriteLine(CapToFront("hApPy"));                       

        object[] arr1 = { "rsq", "6hi", "g", "rsq6hig" };
        Console.WriteLine(MatchLastItem(arr1));                       // False

        double[] nan1 = { 1, 2, double.NaN };
        Console.WriteLine(FindNaN(nan1));                             // -1

        object[] dup1 = { 1, 0, 1, 0 };
        Console.WriteLine(string.Join(", ", RemoveDups(dup1)));     

        Console.WriteLine(ConvertTime("07:05:45PM"));                 
    
        Console.WriteLine(RemoveLastVowel("Those who dare to fail")); 

        int[] cubes = { 1, 5, 9 };
        Console.WriteLine(SumOfCubes(cubes));                         // 855
        Console.ReadLine();
    }
    
}



