using System;
using System.Text;

namespace taskEleven
{
    class testEleven
    {
        static void Main()
        {
            string forbiddenWords = Console.ReadLine();
            string input = Console.ReadLine();
            var output = new StringBuilder(input.Length);
            output.Append(input);
            var keys = forbiddenWords.Split(',');
            var temp = new StringBuilder();
            var inserts = new string[keys.Length];
            int count = 0;

            foreach (var key in keys)
            {
                temp.Clear();
                for (int i = 0; i < key.Length; i++)
                {
                    temp.Append('*');
                }
                inserts[count] = temp.ToString();
                ++count;
            }

            for (int i = 0; i < keys.Length; i++)
            {
                int index = input.IndexOf(keys[i]);

                while (index != -1)
                {
                    output = output.Remove(index, keys[i].Length);
                    output = output.Insert(index, inserts[i]);

                    index = input.IndexOf(keys[i], index + 1);
                }
            }
            Console.WriteLine(output);
        }
    }
}
