using System;

namespace _3cSharp
{
    static class Assist
    {
        static public void NumberCheck(string str, out int number)
        {
            if (int.TryParse(str, out number))
                return;
            Console.WriteLine("Invalid number will be replaced with 0");

        }

        static public bool DefineBool(string word)
        {
            word.ToLower();
            while (true)
            {
                switch (word)
                {
                    case "1":
                    case "da":
                    case "да":
                    case "yes":
                    case "yeah":
                    case "yup": return true;
                    case "0":
                    case "net":
                    case "нет":
                    case "no":
                    case "nope": return false;
                    default: Console.WriteLine("Incorrect input will be replaced with false"); return false;
                }

            }
        }
    }
}