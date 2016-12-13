using System;
class SayHello
{
    static void Main()
    {
        PrintHello(Console.ReadLine());
    }
     static void PrintHello(string name)
    {
        
        Console.WriteLine("Hello, {0}!", name);
    }
}
