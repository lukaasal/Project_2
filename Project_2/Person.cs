using System;

namespace Project_2.Models
{
    public abstract class Person
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        public Person(int rollNumber, string name, string surName, DateTime birthDate)
        {
            RollNumber = rollNumber;
            Name = name;
            SurName = surName;
            BirthDate = birthDate;
        }

        public int CalculateAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                age--;
            return age;
        }

        public override string ToString()
        {
            return $"{Name} {SurName}  {CalculateAge()} years old";
        }
    }
}
