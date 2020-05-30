using System;

namespace Laba8
{
    static public class RaceManager
    {
        static public void Race(IMovable first, IMovable second)
        {
            if (first == null || second == null)
            {
                Console.WriteLine("Sorry, one of chosen vehicles is not raceable");
            }
            else if (first.IsDestroyed || first.IsDestroyed)
            {
                Console.WriteLine("Sorry, one of the vehicles is destroyed");
            }
            else
            {
                first.VehicleDestroyed += delegate (object sender, EventArgs e)
                {
                    Console.WriteLine("{0} is destroyed, it's results are nullified\n", (sender as Vehicle)?.GetFullName() ?? "first");
                    first.QuaterMileTime = 0;
                    first.TrapSpeed = 0;
                };

                second.VehicleDestroyed += delegate (object sender, EventArgs e)
                {
                    Console.WriteLine("{0} is destroyed, it's results are nullified\n", (sender as Vehicle)?.GetFullName() ?? "second");
                    second.QuaterMileTime = 0;
                    second.TrapSpeed = 0;
                };

                first.Race();
                second.Race();
                double firstSpeed = first.TrapSpeed;
                double secondSpeed = second.TrapSpeed;
                if (firstSpeed == 0 && secondSpeed == 0)
                {
                    Console.WriteLine("No winner");
                }
                else
                {
                    Console.WriteLine((firstSpeed > secondSpeed ? "First" : "Second") + " won!\n");
                }
                first.ResetEvent();
                second.ResetEvent();
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}