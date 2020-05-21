using System;
using System.Collections.Generic;
using System.Linq;


namespace _3cSharp
{
    class MainClass
    {
        static void AllVehicleInfo(List<Vehicle> garage)
        {
            foreach (Vehicle vehicle in garage)
            {
                vehicle.PrintInfo();
            }
        }

        static void VehicleChoice(List<Vehicle> garage, out int index)
        {

            int size = garage.Count();
            do
            {
                Console.WriteLine("Choose the vehicle by its id (from 0 to {0})", size);
                Assist.NumberCheck(Console.ReadLine(), out index);
            } while (index >= size);

        }

        static public void InfoCorrect(Vehicle vehicle)
        {
            Console.WriteLine("What exactly do you want to correct : \n1 - Type\n2 - Color\n3 - Wheels\n4 - Speed\n5 - Distance\n6 - Condtition\n7 - Exit");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1: Console.WriteLine("Correct type is : "); vehicle.Type = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D2: Console.WriteLine("Correct color is : "); vehicle.Color = Console.ReadLine(); Console.Clear(); break;
                case ConsoleKey.D3: Console.WriteLine("Correct amount of wheels is : "); vehicle.Wheels = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D4: Console.WriteLine("Correct speed is : "); vehicle.Speed = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D5: Console.WriteLine("Correct distance is : "); vehicle.Distance = int.Parse(Console.ReadLine()); Console.Clear(); break;
                case ConsoleKey.D6: Console.WriteLine("Correct condition is : "); vehicle.IsBroken = bool.Parse(Console.ReadLine()); Console.Clear(); break;
                default: return;
            }
        }

        static public Vehicle AddNewVehicle()
        {
            Console.WriteLine("Type : ");
            string type = Console.ReadLine();
            Console.WriteLine("Color : ");
            string color = Console.ReadLine();
            Console.WriteLine("Wheels : ");
            int wheels;
            Assist.NumberCheck(Console.ReadLine(), out wheels);
            Console.WriteLine("Speed : ");
            int speed;
            Assist.NumberCheck(Console.ReadLine(), out speed);
            Console.WriteLine("Distance : ");
            int distance;
            Assist.NumberCheck(Console.ReadLine(), out distance);
            Console.WriteLine("Broken : ");

            string isBroken = (Console.ReadLine());

            bool izBroken = Assist.DefineBool(isBroken);

            return new Vehicle(type, speed, wheels, color, izBroken, distance);
        }



        static void Main(string[] args)
        {
            Vehicle car = new Vehicle();
            List<Vehicle> garage = new List<Vehicle>();
            garage.Add(car);
            int index;
            do
            {
                Console.WriteLine("Your garage : \n1 - Add\n2 - Info about my vehicles\n3 - Throw Vehicle Away\n4 - Correct info\n5 - Test Drive\n6 - Repair\n7 - Exit");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); garage.Add(AddNewVehicle()); Console.Clear(); break;
                    case ConsoleKey.D2: Console.Clear(); AllVehicleInfo(garage); Console.ReadKey(); Console.Clear(); break;
                    case ConsoleKey.D3: Console.Clear(); VehicleChoice(garage, out index); garage.Remove(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D4: Console.Clear(); VehicleChoice(garage, out index); garage[index].PrintInfo(); InfoCorrect(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D5: Console.Clear(); VehicleChoice(garage, out index); garage[index].Ride(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D6: Console.Clear(); VehicleChoice(garage, out index); garage[index].Repair(garage[index]); Console.Clear(); break;
                    case ConsoleKey.D7: return;
                    default: Console.Clear(); break;
                }

            } while (true);
        }
    }
}