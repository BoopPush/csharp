using System;
using System.Collections.Generic;

namespace Laba8
{
    public enum ChoosableCars { Car, AudiRS, MazdaRX, ToyotaSupra }

    public class Program
    {
        static public void PrintGarage(List<Vehicle> garage)
        {
            int size = garage.Count;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine((i + 1).ToString() + "." + garage[i].GetFullName());
            }
        }

        static public Vehicle SelectVehicle(List<Vehicle> garage)
        {
            Console.Clear();
            int size = garage.Count;
            int selection;
            PrintGarage(garage);
            do
            {
                Console.WriteLine("\nEnter car number: ");
                NumberChecker.CheckNumber(Console.ReadLine(), out selection);
            } while (selection > size || selection <= 0);
            Console.Clear();
            return garage[selection - 1];
        }

        static public void TuneVehicle(Vehicle vehicle)
        {
            Console.Clear();
            if (vehicle is ITunable)
            {
                bool decision = true;
                Console.WriteLine("Do you want to:\n1.Tune\n2.Untune\n");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1:
                        decision = true;
                        break;
                    case ConsoleKey.D2:
                        decision = false;
                        break;
                    default:
                        Console.WriteLine("Car will be tuned");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                ITunable tunableCar = vehicle as ITunable;
                if (decision)
                {
                    tunableCar.Tune();
                }
                else
                {
                    tunableCar.UnTune();
                }
                Console.WriteLine("{0} new characteristics:\n", vehicle.GetFullName());
                Console.WriteLine(vehicle.GetInfo());
            }
            else
            {
                Console.WriteLine("Sorry, it cannot be tuned");
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void ChooseVehicleType(List<Vehicle> garage)
        {
            Console.Clear();
            Console.WriteLine("Which type of vehicle do you want to add:\n1.Car\n2.Audi RS4\n3.Mazda RX7\n4.Toyota Supra\n5.Motorcycle\n6.Other\n7.Exit ");
            switch (Console.ReadKey(false).Key)
            {

                case ConsoleKey.D1: Console.Clear(); garage.Add(AddNewCar(ChoosableCars.Car)); Console.Clear(); break;

                case ConsoleKey.D2: Console.Clear(); garage.Add(AddNewCar(ChoosableCars.AudiRS)); Console.Clear(); break;

                case ConsoleKey.D3: Console.Clear(); garage.Add(AddNewCar(ChoosableCars.MazdaRX)); Console.Clear(); break;

                case ConsoleKey.D4: Console.Clear(); garage.Add(AddNewCar(ChoosableCars.ToyotaSupra)); Console.Clear(); break;

                case ConsoleKey.D5: Console.Clear(); garage.Add(AddNewMotorcycle()); Console.Clear(); break;

                case ConsoleKey.D6: Console.Clear(); garage.Add(AddNewVehicle()); Console.Clear(); break;

                case ConsoleKey.D7: return;
            }
        }

        static public Vehicle AddNewCar(ChoosableCars chosenCar)
        {
            Console.Clear();
            Console.WriteLine("Color: ");
            string color = Console.ReadLine();
            switch (chosenCar)
            {
                case ChoosableCars.Car:
                    Console.WriteLine("CarConfiguration:\n1.Sedan\n2.Wagon\n3.Hatchback\n4.Coupe\n");
                    NumberChecker.CheckNumber(Console.ReadLine(), out int configuration);
                    Console.WriteLine("Weight(kg): ");
                    NumberChecker.CheckNumber(Console.ReadLine(), out int weight);
                    Console.WriteLine("Power(hp): ");
                    NumberChecker.CheckNumber(Console.ReadLine(), out int horsePower);
                    Console.WriteLine("Length(m): ");
                    NumberChecker.CheckNumber(Console.ReadLine(), out int length);
                    Console.WriteLine("Width(m): ");
                    NumberChecker.CheckNumber(Console.ReadLine(), out int width);
                    Console.WriteLine("Height(m): ");
                    NumberChecker.CheckNumber(Console.ReadLine(), out int height);
                    return new Car(color, (CarConfiguration)configuration, weight, horsePower, length, width, height);
                case ChoosableCars.AudiRS:
                    return new AudiRS(color);
                case ChoosableCars.MazdaRX:
                    return new MazdaRX(color);
                case ChoosableCars.ToyotaSupra:
                    return new ToyotaSupra(color);
                default:
                    return new Car();
            }
        }

        static public Motorcycle AddNewMotorcycle()
        {
            Console.WriteLine("Color: ");
            string color = Console.ReadLine();
            Console.WriteLine("BikeConfiguration:\n1.Sport\n2.Standart\n3.Dirt\n");
            NumberChecker.CheckNumber(Console.ReadLine(), out int configuration);
            Console.WriteLine("Weight(kg): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int weight);
            Console.WriteLine("Power(hp): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int horsePower);
            Console.WriteLine("Length(m): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int length);
            Console.WriteLine("Width(m): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int width);
            Console.WriteLine("Height(m): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int height);
            return new Motorcycle(color, (BikeConfiguration)configuration, weight, horsePower, length, width, height);
        }

        static public Vehicle AddNewVehicle()
        {
            Console.WriteLine("Color: ");
            string color = Console.ReadLine();
            Console.WriteLine("Type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Weight(kg): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int weight);
            Console.WriteLine("Wheels: ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int wheels);
            Console.WriteLine("Length(m): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int length);
            Console.WriteLine("Width(m): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int width);
            Console.WriteLine("Height(m): ");
            NumberChecker.CheckNumber(Console.ReadLine(), out int height);
            return new Vehicle(type, color, wheels, weight, length, width, height);
        }

        static public void ShowGarage(List<Vehicle> garage)
        {
            Console.Clear();
            foreach (Vehicle vehicle in garage)
            {
                Console.WriteLine(vehicle.GetInfo());
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void Main()
        {

            Car car = new Car();
            Vehicle vehicle = new Vehicle();
            AudiRS audi = new AudiRS("blue");
            ToyotaSupra toyota = new ToyotaSupra("red");
            MazdaRX mazda = new MazdaRX("green");
            Motorcycle bike = new Motorcycle("orange");
            List<Vehicle> garage = new List<Vehicle>
            {
                car,
                audi,
                toyota,
                mazda,
                vehicle,
                bike
            };
            ConsoleMenu mainMenu = new ConsoleMenu
            {
                new MenuEntry("Add", new Action(() => { ChooseVehicleType(garage); })),
                new MenuEntry("Show all", new Action(() => { ShowGarage(garage); })),
                new MenuEntry("Tune", new Action(() => { TuneVehicle(SelectVehicle(garage)); })),
                new MenuEntry("Sell", new Action(() => { garage.Remove(SelectVehicle(garage)); })),
                new MenuEntry("Race", new Action(() => { RaceManager.Race(SelectVehicle(garage) as IMovable, SelectVehicle(garage) as IMovable); })),
                new MenuEntry("Exit", new Action(() => { Environment.Exit(0); }))
            };
            do
            {
                Console.WriteLine(mainMenu.PrintMenu('.'));
                NumberChecker.CheckNumber(Console.ReadLine(), out int decision);
                mainMenu.ExecuteEntry(decision);
            } while (true);
        }
    }
}
