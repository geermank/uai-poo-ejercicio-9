using System;

namespace ObservatoryProject
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime dob;

        public Person(string firstName, string lastName, DateTime dob)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public DateTime Dob
        {
            get { return dob; }
        }
    }
}