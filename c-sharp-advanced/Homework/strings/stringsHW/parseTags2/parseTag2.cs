using System;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        var upper = text.Split(new[] { "</upcase>", "<upcase>" }, StringSplitOptions.None);

        for (int i = 1; i < upper.Length; i += 2)
        {
            upper[i] = upper[i].ToUpper();
        }
        Console.WriteLine(string.Join("", upper));
    }
}