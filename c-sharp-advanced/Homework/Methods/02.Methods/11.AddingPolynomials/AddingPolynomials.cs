using System;
class AddingPolynomials
{
    static int[] GetSum(int n)
    {

        int[] first = GetArray(Console.ReadLine().Split(' '));
        int[] second = GetArray(Console.ReadLine().Split(' '));
        int[] sum = new int[n];
        for (int i = 0; i < n; i++)
        {
            sum[i] = first[i] + second[i];
        }
        return sum;
    }

    static int[] GetArray(string[] members)
    {
        int[] array = new int[members.Length];
        for (int i = 0; i < members.Length; i++)
        {
            array[i] = int.Parse(members[i]);
        }
        return array;
    }

    static void PrintSum(int[] sum)
    {
        foreach (int member in sum)
        {
            Console.Write("{0} ", member);
        }
    }

    static void Main()
    {
        PrintSum(GetSum(int.Parse(Console.ReadLine())));
    }
}
