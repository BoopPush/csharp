using System;
using System.Collections.Generic;
using System.Text;

namespace Laba8
{
    public enum BikeConfiguration { Sport, Standart, Dirt }

    public class Motorcycle : Vehicle, IMovable, IComparable
    {
        public event EventHandler VehicleDestroyed;
        public BikeConfiguration Configuration { get; set; }
        public float HorsePower { get; set; }
        public double QuaterMileTime { get; set; }
        public double TrapSpeed { get; set; }

        public bool IsDestroyed { get; set; }

        public Motorcycle(string color = "blue", BikeConfiguration configuration = BikeConfiguration.Standart,
           float weight = 300, float horsePower = 50, float length = 1f, float width = 0.4f, float height = 1.1f, bool isDestroyed = false)
               : base("motorcycle", color, 2, weight, length, width, height)
        {
            Configuration = configuration;
            HorsePower = horsePower;
            IsDestroyed = isDestroyed;
            MeasureResults();
        }

        public void MeasureResults()
        {
            QuaterMileTime = Math.Pow(2.205 * Weight / HorsePower, 1f / 3) * 6.825; //другие коэффициенты
            TrapSpeed = Math.Pow(HorsePower / (Weight * 2.205), 1f / 3) * 288;
        }

        public void Race()
        {
            Random rand = new Random();
            if (!IsDestroyed)
            {
                int chance = rand.Next(1, 3);
                IsDestroyed = (chance == 1) ? true : false;
            }
            if (IsDestroyed)
            {
                OnVehicleDestroyed(EventArgs.Empty);
                return;
            }
            MeasureResults();
            Console.WriteLine(GetResults());
        }

        protected void OnVehicleDestroyed(EventArgs e)
        {
            VehicleDestroyed?.Invoke(this, e);
        }

        public void ResetEvent()
        {
            VehicleDestroyed = null;
        }

        public string GetResults()
        {
            return string.Format("{0} went 1/4 mile with the exit speed of {1:F2} in {2:F2}\n", GetFullName(), TrapSpeed, QuaterMileTime);
        }

        public override string GetFullName()
        {
            return Color + " " + Configuration + "Bike";
        }

        public override string GetInfo()
        {
            if (IsDestroyed)
            {
                return string.Format("{0}\nDestroyed\n", GetFullName());
            }
            else
            {
                return string.Format("{0}\n  Weight: {1}kg\n  HorsePower: {2}hp\n  Length: {3}m\n  Width: {4}m\n  Height: {5}m\n", GetFullName(), Weight, HorsePower, Size.length, Size.width, Size.height);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is Motorcycle otherMotorcycle)
                return this.HorsePower.CompareTo(otherMotorcycle.QuaterMileTime);
            else
                throw new ArgumentException("Object is not a motorcycle");
        }
    }
}