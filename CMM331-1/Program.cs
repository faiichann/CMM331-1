using System;

namespace CMM331_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Hello CMM331");
            Console.Write("Image Processing");
            Console.WriteLine("");
            for (int i=0; i< 10; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            for (int i=0; i<10;i++)
            {
                for (int j=0; j<10; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("What is your name");
            String name = Console.ReadLine();
            Console.WriteLine("Hello  {0}", name);
        }
    }
}
