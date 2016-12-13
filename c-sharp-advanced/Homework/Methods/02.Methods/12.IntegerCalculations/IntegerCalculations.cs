using System;
using System.Linq;
class IntegerCalculations
{
    static void Main()
    {
        int[] myArray = ArrayInput();
        long product = 1;
        foreach (int element in myArray)
	{
        product *= element;
	}
        Console.WriteLine(myArray.Min());
        Console.WriteLine(myArray.Max());
        Console.WriteLine("{0:F2}", myArray.Average());
        Console.WriteLine(myArray.Sum());
        Console.WriteLine(product);

    }
    static int[] ArrayInput(int arraySize = 5)
    {
        string[] stringArray = Console.ReadLine().Split(' ');
        int[] arrayAsInt = new int[stringArray.Length];
        for (int i = 0; i <= arraySize - 1; i++)
        {
            arrayAsInt[i] = int.Parse(stringArray[i]);
        }

        return arrayAsInt;
    }

}

