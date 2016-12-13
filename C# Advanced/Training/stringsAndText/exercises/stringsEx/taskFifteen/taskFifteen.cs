using System;
using System.Collections.Generic;

namespace taskFifteen
{
    class taskFifteen
    {
        static void Main()
        {
            Console.WriteLine("How many entries?");
            int entries = int.Parse(Console.ReadLine());
            var words = new List<string>(entries);
            var explanations = new List<string>(entries);

            for (int i = 0; i < entries; i++)
            {
                string input = Console.ReadLine();
                int indexEnd = input.IndexOf(' ');
                words.Add(input.Substring(0, indexEnd));
                int indexStart = input.IndexOf(' ', indexEnd + 1);
                explanations.Add(input.Substring(indexStart + 1));
            }

            Console.WriteLine("Search");
            string search = Console.ReadLine();

            while (search != "end")
            {
                int index = -1;
                for (int i = 0; i < words.Count; i++)
                {
                    if (search.Equals(words[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    Console.WriteLine(explanations[index]);
                }
                else
                {
                    Console.WriteLine("That word is not in the dictionary");
                }

                search = Console.ReadLine();
            }
        }
    }
}
