namespace ObservatoryProject
{
    public abstract class BaseDistance
    {
        protected double value;
        
        public BaseDistance(double value)
        {
            this.value = value;
        }

        public double Value
        {
            get { return value; }
        }

        public abstract string GetDistance();
    }
}