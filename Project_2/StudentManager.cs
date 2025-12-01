using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Models
{
    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public StudentManager() { }

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student added: {student.RollNumber} {student.Name} {student.SurName} {student.BirthDate.ToShortDateString()} {student.Grade}");
        }

        public void RemoveStudent(int rollNumber)
        {
            var student = students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student deleted: {student.Name} {student.SurName}");
            }
        }

        public void ShowAll()
        {
            Console.WriteLine("\n--- Student List ---");

            if (students.Count == 0)
            {
                Console.WriteLine("List is empty!");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"List: {student.RollNumber} {student.Name} {student.SurName} {student.BirthDate.ToShortDateString()} {student.Grade}");
            }
        }
    }
}
