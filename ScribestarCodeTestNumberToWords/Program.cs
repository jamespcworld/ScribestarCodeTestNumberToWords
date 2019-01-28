using SimpleInjector;
using System;
using System.Diagnostics;
using System.Linq;

namespace ScribestarCodeTestNumberToWords
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Register<INumberSpeller, NumberSpeller>();
            container.Verify();
        }
        static void Main(string[] args)
        {
            var foo = Console.ReadLine();

            if (int.TryParse(foo, out int num))
            {
                var numberSpeller = container.GetInstance<NumberSpeller>();
                var words = numberSpeller.SpellNumber(num);
                Console.WriteLine($"{num} = {words}");
            }
            else
            {
                Console.WriteLine($"{foo} is not a number");

            }
            Console.ReadLine();
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
