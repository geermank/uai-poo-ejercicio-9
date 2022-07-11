using System;

namespace ObservatoryProject
{
    public class LightYears : BaseDistance
    {
        public LightYears(double value) : base(value)
        {
            // empty constructor
        }

        public override string GetDistance()
        {
            return value + " años luz";
        }
    }
}