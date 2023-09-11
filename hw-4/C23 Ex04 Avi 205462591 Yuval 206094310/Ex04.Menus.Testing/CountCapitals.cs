using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Testing
{
    public class CountCapitals : IInvoker
    {
        public void Invoke()
        {
            FunctionCountCapitals();
        }

        public static void FunctionCountCapitals()
        {
            Console.WriteLine("Please Enter a string");
            string input = Console.ReadLine();
            int count = 0;

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }
            }

            Console.WriteLine(String.Format("There are {0} capital letters in the string.", count));
        }
    }
}
