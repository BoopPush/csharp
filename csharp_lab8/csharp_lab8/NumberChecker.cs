using System;
using System.Collections.Generic;
using System.Text;

namespace Laba8
{
    static public class NumberChecker
    {
        static public void CheckNumber(string line, out int number)
        {
            try
            {
                if (!int.TryParse(line, out number))
                    throw new ArgumentException();
                else return;
            }

            catch (ArgumentException)
            {
                while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
                {
                    Console.WriteLine("Error! Please, enter positive integer: ");
                }
            }
        }
        static public void CheckNumber(string line, out float number)
        {
            try
            {
                if (!float.TryParse(line, out number))
                    throw new ArgumentException();
                else return;
            }

            catch (ArgumentException)
            {
                while (!float.TryParse(Console.ReadLine(), out number) || number <= 0)
                {
                    Console.WriteLine("Error! Please, enter positive fractional number: ");
                }
            }
        }
    }
}