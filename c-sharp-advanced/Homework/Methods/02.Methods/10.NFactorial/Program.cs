using System;
using System.Numerics;
class Program
{
    static BigInteger GetFactorial(int n)
    {
        BigInteger[] array = new BigInteger[n];
        BigInteger factorial = n;
        for (int i = 1; i <= array.Length; i++)
        {
            array[i - 1] = i;
        }
        for (int i = 0; i < array.Length - 1; i++)
        {
            factorial *= array[i];
        }
        return factorial;
    }
    static void Main()
    {
        Console.WriteLine(GetFactorial(int.Parse(Console.ReadLine())));
    }
}
