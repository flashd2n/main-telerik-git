using System;
class AppearanceCount
{
    static void Main()
    {
        GetNumberCount(int.Parse(Console.ReadLine()),Console.ReadLine().Split(' '),int.Parse(Console.ReadLine()));
    }
    static void GetNumberCount(int n, string[] array, int x)
    {
        int counter = 0;
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(array[i]);
            if (x == numbers[i])
            {
                counter++;
            }
        }
        Console.WriteLine(counter);


    }
}
