using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservatoryProject
{
    public class Kilometers : BaseDistance
    {
        public Kilometers(double value) : base(value)
        {
            // empty constructor
        }

        public override string GetDistance()
        {
            return value + " KM";
        }
    }
}