using System;
class FirstLargerThanNeighbours
{
    static void Main()
    {
        GetFirstLargerThanNeighbours(int.Parse(Console.ReadLine()), Console.ReadLine().Split(' '));
    }
    static void GetFirstLargerThanNeighbours(int n, string[] array)
    {
        int result;
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(array[i]);

        }
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && i < n - 1 && numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
            {
                result = i;
                Console.WriteLine(result);
                break;
            }
        }
    }
}
