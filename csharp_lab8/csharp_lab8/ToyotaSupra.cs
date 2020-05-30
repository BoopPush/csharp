using System;

namespace Laba8
{
    class ToyotaSupra : Car, ITunable
    {
        public event Action OnDamaged;
        public ToyotaSupra(string color = "red", bool isTuned = false) : base(color, length: 4.38f, width: 1.85f, height: 1.29f)
        {
            Configuration = CarConfiguration.Sedan;
            Weight = 1495f;
            HorsePower = 350f;
            if (isTuned)
            {
                Tune();
            }
            MeasureResults();
        }
        public void Tune()
        {
            if (OnDamaged == null)
            {
                OnDamaged += delegate
                {
                    Console.WriteLine("Sorry, car couldnt handle that tuning - its characteristics are lowered\n");
                    HorsePower /= 2;
                    Weight *= 1.3f;
                };
            }

            Random rand = new Random();
            int chance = rand.Next(1, 4);
            if (chance == 1 && OnDamaged != null)
            {
                OnDamaged?.Invoke();
                return;
            }
            else
            {
                HorsePower *= 1.1f;
                Weight *= 0.95f;
            }
        }

        public void UnTune()
        {
            HorsePower *= 0.9f;
            Weight *= 1.05f;
        }

        public override string GetFullName()
        {
            return Color + " Toyota Supra";
        }
    }
}