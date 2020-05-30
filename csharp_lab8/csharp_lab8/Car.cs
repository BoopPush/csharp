using System;

namespace Laba8
{
    public enum CarConfiguration { Sedan, Wagon, Hatchback, Coupe }

    public class Car : Vehicle, IMovable, IComparable
    {
        public event EventHandler VehicleDestroyed;
        public CarConfiguration Configuration { get; set; }
        public float HorsePower { get; set; }
        public double QuaterMileTime { get; set; }
        public double TrapSpeed { get; set; }

        public bool IsDestroyed { get; set; }

        public Car(string color = "blue", CarConfiguration configuration = CarConfiguration.Sedan,
            float weight = 1971, float horsePower = 400, float length = 4.5f, float width = 2.2f, float height = 1.1f, bool isDestroyed = false)
                : base("car", color, 4, weight, length, width, height)
        {
            Configuration = configuration;
            HorsePower = horsePower;
            IsDestroyed = isDestroyed;
            MeasureResults();
        }

        public override string GetFullName()
        {
            return Color + " " + Configuration;
        }

        public void MeasureResults()
        {
            QuaterMileTime = Math.Pow(2.205 * Weight / HorsePower, 1f / 3) * 5.825;
            TrapSpeed = Math.Pow(HorsePower / (Weight * 2.205), 1f / 3) * 246;
        }

        public void Race()
        {
            Random rand = new Random();
            if (!IsDestroyed)
            {
                int chance = rand.Next(1, 6);
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
            return string.Format("{0} went 1/4 mile in {1:F2} seconds with the trap speed of {2:F2} km/h\n", GetFullName(), QuaterMileTime, TrapSpeed);
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

            if (obj is Car otherCar)
                return this.QuaterMileTime.CompareTo(otherCar.QuaterMileTime);
            else
                throw new ArgumentException("Object is not a car");
        }
    }
}