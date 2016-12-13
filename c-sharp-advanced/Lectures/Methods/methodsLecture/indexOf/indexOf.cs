using System;

namespace indexOf
{
    class indexOf
    {

        static int IndexOf(char[] symbols, char searchValue)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == searchValue)
                {
                    return i;
                }



            }


            return -1;
        }


        static void Main()
        {

            char[] symbolsArr = "this is a string".ToCharArray();

            int theIndex = IndexOf(symbolsArr, 'g');
            int theIndexTwo = IndexOf(symbolsArr, 'p');

            Console.WriteLine("g -> {0}", theIndex);
            Console.WriteLine("p -> {0}", theIndexTwo);

        }
    }
}
