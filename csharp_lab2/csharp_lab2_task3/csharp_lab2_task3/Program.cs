using System;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your line ");
            string test = Console.ReadLine();
            string result = new string(test.Where(c => !((c > 0x40 && c < 0x5B) || (c > 0x60 && c < 0x7B))).ToArray());
            string result1 = new string(result.Where(e => char.IsLetter(e)).ToArray());
            Console.WriteLine(result);
            for (int i = 0; i < result.Length; i++)
            {
                if (result1[i] == result1.ToUpper()[i])
                {
                    Console.WriteLine("Big letter: {0} ", result1[i]);
                }
            }

        }
    }
}
