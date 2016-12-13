using System;
class ReverseNumber
{
    static void Main()
    {

        string numbers = Console.ReadLine();
        Console.WriteLine(GetReverse(numbers));
    }

    static string GetReverse(string numbers)
    {
        char[] array = numbers.ToCharArray();
        Array.Reverse(array);
        string numberToString = new string(array);

        return numberToString;
    }
}
