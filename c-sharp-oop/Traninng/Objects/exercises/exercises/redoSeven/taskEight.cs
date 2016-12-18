using System;
using System.Collections.Generic;
using redoSeven.folder;
using redoSeven.folderTwo;

namespace redoSeven
{
    class taskEight
    {
        static void Main()
        {
            List<Cat> array = new List<Cat>();

            for (int i = 0; i < 10; i++)
            {
                var cat = new Cat($"cat{Sequence.NextValue()}", "blue");
                array.Add(cat);
            }

            for (int i = 0; i < 10; i++)
            {
                array[i].SayMiau();
            }
        }

    }
}
