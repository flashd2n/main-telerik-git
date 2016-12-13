using System;
class LargerThanNeighbours
{
    static void Main()
    {
        GetLargerThanNeighbours(int.Parse(Console.ReadLine()), Console.ReadLine().Split(' '));
    }

    static void GetLargerThanNeighbours(int n, string[] array)
    {
        int counter = 0;
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(array[i]);

        }
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && i < n - 1 && numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
            {
                counter++;
            }
        }
        Console.WriteLine(counter);


    }
}
