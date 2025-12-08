using System;

namespace Project_2.Models
{
    public class Student : Person
    {
        public double Grade { get; set; }

        public Student() { }

        public Student(int rollNumber, string name, string surname, DateTime birthDate, double grade)
            : base(rollNumber, name, surname, birthDate)
        {
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Grade: {Grade}";
        }
    }
}
