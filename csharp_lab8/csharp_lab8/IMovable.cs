using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    public interface IMovable
    {
        event EventHandler VehicleDestroyed;
        double TrapSpeed { get; set; }

        double QuaterMileTime { get; set; }

        bool IsDestroyed { get; set; }

        void MeasureResults();

        void Race();

        void ResetEvent();
    }
}