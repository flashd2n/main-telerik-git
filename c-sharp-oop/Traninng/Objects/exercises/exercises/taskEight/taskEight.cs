using System;

namespace taskEight
{
    class taskEight
    {
        static void Main()
        {
            for (int i = 1; i <= 10; i++)
            {
                var cat = new Cat();
                cat.Name = $"Cat{i}";
                cat.SayMiau();
            }


        }
    }
}