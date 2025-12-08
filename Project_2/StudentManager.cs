using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Models
{
    public class StudentManager
    {
        private readonly List<Student> _students = new();

        public void AddStudent(Student student)
        {
            _students.Add(student);
            Console.WriteLine($"Added: {student}");
        }

        public void RemoveStudent(int rollNumber)
        {
            var student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (student == null)
            {
                Console.WriteLine("No student found with that roll number.");
                return;
            }

            _students.Remove(student);
            Console.WriteLine($"Removed: {student.Name} {student.Surname}");
        }

        public void ShowAll()
        {
            Console.WriteLine("\n--- Students ---");

            if (_students.Count == 0)
            {
                Console.WriteLine("No students registered.\n");
                return;
            }

            foreach (var student in _students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
        }
    }
}
