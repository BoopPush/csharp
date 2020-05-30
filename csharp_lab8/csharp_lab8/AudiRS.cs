using System;

namespace Laba8
{
    class AudiRS : Car
    {
        public AudiRS(string color = "blue") : base(color, length: 4.78f, width: 1.86f, height: 1.4f)
        {
            Configuration = CarConfiguration.Hatchback;
            Weight = 1771f;
            HorsePower = 450f;
            MeasureResults();
        }

        public override string GetFullName()
        {
            return Color + " AudiRS4";
        }
    }
}