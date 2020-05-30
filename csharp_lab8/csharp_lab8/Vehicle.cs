using System;

namespace Laba8
{

    public struct Size
    {
        public float length;
        public float width;
        public float height;
        public Size(float l, float w, float h)
        {
            length = l;
            width = w;
            height = h;
        }
    }

    public class Vehicle
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public float Weight { get; set; }
        public Size Size { get; set; }

        public Vehicle(string type = "Bicycle", string color = "blue", int wheels = 2, float weight = 15, float length = 1f, float width = 0.1f, float height = 1.1f)
        {
            Type = type;
            Color = color;
            Wheels = wheels;
            Weight = weight;
            Size = new Size(length, width, height);
        }

        public virtual string GetFullName()
        {
            return Color + " " + Wheels + "-wheel " + Type;
        }

        public virtual string GetInfo()
        {
            return string.Format("{0}\n  Weight: {1}kg\n", GetFullName(), Weight);
        }
    }
}