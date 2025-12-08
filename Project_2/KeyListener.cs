using System;
using Project_2.Models;

namespace Project_2
{
    public class KeyListener
    {
        private readonly StudentManager _manager;

        public KeyListener(StudentManager manager)
        {
            _manager = manager;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- Student Manager ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Show All Students");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudentFromUser();
                        break;
                    case "2":
                        RemoveStudentFromUser();
                        break;
                    case "3":
                        _manager.ShowAll();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void AddStudentFromUser()
        {
            try
            {
                Console.Write("Roll Number: ");
                int roll = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Surname: ");
                string surname = Console.ReadLine() ?? string.Empty;

                Console.Write("Birth Year: ");
                int year = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Birth Month: ");
                int month = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Birth Day: ");
                int day = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("Grade: ");
                double grade = double.Parse(Console.ReadLine() ?? string.Empty);

                var student = new Student(roll, name, surname, new DateTime(year, month, day), grade);
                _manager.AddStudent(student);
            }
            catch
            {
                Console.WriteLine("Invalid input. Student was not added.");
            }
        }

        private void RemoveStudentFromUser()
        {
            Console.Write("Enter roll number: ");
            if (int.TryParse(Console.ReadLine(), out int roll))
            {
                _manager.RemoveStudent(roll);
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }
}
