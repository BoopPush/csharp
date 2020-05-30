using System;

namespace Laba8
{
    class MazdaRX : Car, ITunable
    {
        public event Action OnDamaged;
        public MazdaRX(string color = "green", bool isTuned = false) : base(color, length: 4.29f, width: 1.76f, height: 1.23f)
        {
            Configuration = CarConfiguration.Coupe;
            Weight = 1330f;
            HorsePower = 252f;
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
                HorsePower *= 1.2f;
                Weight *= 0.9f;
            }
        }

        public void UnTune()
        {
            HorsePower *= 0.83f;
            Weight *= 1.11f;
        }

        public override string GetFullName()
        {
            return Color + " Mazda RX-7";
        }
    }
}