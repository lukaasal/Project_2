using System;

namespace Project_2.Models
{
    public class Student : Person
    {
        public double Grade { get; set; }

        public Student() { }

        public Student(int rollNumber, string name, string surName, DateTime birthDate, double grade)
            : base(rollNumber, name, surName, birthDate)
        {
            Grade = grade;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tGrade: {Grade}";
        }
    }
}
