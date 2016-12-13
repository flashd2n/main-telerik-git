using System;
class GetLargestNumber
{
    
    static void Main()
    {
        GetMax(Console.ReadLine().Split(' '));
    }
    static void GetMax(string[] numbers)
    {

        int a = int.Parse(numbers[0]);
        int b = int.Parse(numbers[1]);
        int c = int.Parse(numbers[2]);
        int largestNum = Math.Max(Math.Max(a, b), c);
        Console.WriteLine(largestNum);


    }
}