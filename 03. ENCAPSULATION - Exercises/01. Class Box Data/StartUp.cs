using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box box = null;

            try
            {
                double length = double.Parse(Console.ReadLine());

                double width = double.Parse(Console.ReadLine());

                double height = double.Parse(Console.ReadLine());

                box = new Box(length, width, height);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine(box);
        }
    }
}
