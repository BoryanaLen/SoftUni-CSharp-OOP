using System;

namespace ProjectFerrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}
