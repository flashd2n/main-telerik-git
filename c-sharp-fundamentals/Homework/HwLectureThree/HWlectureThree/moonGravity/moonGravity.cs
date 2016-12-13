using System;

namespace moonGravity
{
    class moonGravity
    {
        static void Main(string[] args)
        {
            float w = float.Parse(Console.ReadLine());
            float massMoon = (float)(w * 0.17);
            Console.WriteLine(string.Format("{0:0.000}", massMoon));
        }
    }
}
