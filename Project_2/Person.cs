using System;

namespace Project_2.Models
{
    public abstract class Person
    {
        public int RollNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        protected Person() { }

        protected Person(int rollNumber, string name, string surname, DateTime birthDate)
        {
            RollNumber = rollNumber;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (today < BirthDate.AddYears(age)) age--;
                return age;
            }
        }

        public override string ToString() => $"{Name} {Surname}, {Age} years old";
    }
}
