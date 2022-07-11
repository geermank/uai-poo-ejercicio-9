namespace ObservatoryProject
{
    public abstract class Temperature
    {
        protected float value;

        public Temperature(float value)
        {
            this.value = value;
        }

        public float Value
        {
            get { return value; }
        }

        public abstract string GetTemperature();

        public override bool Equals(object obj)
        {
            return obj is Temperature && (obj as Temperature).Value == this.Value; 
        }
    }
}