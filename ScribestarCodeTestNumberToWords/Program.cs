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
            Console.WriteLine("Please enter numbers (Press q to quit):");
            var userInput = Console.ReadLine();

            while (userInput != "q")
            {
                if (int.TryParse(userInput, out int num))
                {
                    var numberSpeller = container.GetInstance<NumberSpeller>();
                    var words = numberSpeller.SpellNumber(num);
                    Console.WriteLine($"{num} = {words}");
                }
                else
                {
                    Console.WriteLine($"{userInput} is not a number");

                }
                userInput= Console.ReadLine();
            }
        }
    }
}
