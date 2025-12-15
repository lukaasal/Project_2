using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Project_2.Models
{
    public class StudentManager
    {
        private readonly List<Student> _students = new();
        private readonly string _filePath = "students.json";

        public StudentManager()
        {
            LoadFromJson();
        }

        public bool AddStudent(Student student)
        {
            if (_students.Any(s => s.RollNumber == student.RollNumber))
            {
                Console.WriteLine($"Error: A student with Roll Number {student.RollNumber} already exists.");
                return false;
            }

            _students.Add(student);
            SaveToJson();
            Console.WriteLine($"Added: {student}");
            return true;
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
            SaveToJson();
            Console.WriteLine($"Removed: {student.Name} {student.Surname}");
        }

        public void ShowAll()
        {
            Console.WriteLine("\n-- Students --");

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

        private void SaveToJson()
        {
            var json = JsonSerializer.Serialize(
                _students,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(_filePath, json);
        }

        private void LoadFromJson()
        {
            if (!File.Exists(_filePath))
                return;

            var json = File.ReadAllText(_filePath);
            var students = JsonSerializer.Deserialize<List<Student>>(json);

            if (students != null)
                _students.AddRange(students);
        }
    }
}
