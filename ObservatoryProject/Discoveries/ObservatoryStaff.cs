using System;

namespace ObservatoryProject
{
    public class ObservatoryStaff : Person
    {
        private string file;

        public ObservatoryStaff(string firstName, string lastName, DateTime dob, string file) : base(firstName, lastName, dob)
        {
            this.file = file;
        }

        public string File
        {
            get { return file; }
        }
    }
}