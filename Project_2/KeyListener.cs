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
                Console.WriteLine("\n-- Student Manager --");
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
                int roll;
                // --- Roll Number ---
                while (true)
                {
                    Console.Write("Roll Number: ");
                    if (int.TryParse(Console.ReadLine(), out roll))
                        break;
                    Console.WriteLine("Invalid input. Roll Number must be a number.");
                }

                // --- Name ---
                string name;
                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit))
                        Console.WriteLine("Invalid input. Name cannot contain numbers or be empty.");
                } while (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit));

                // --- Surname ---
                string surname;
                do
                {
                    Console.Write("Surname: ");
                    surname = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(surname) || surname.Any(char.IsDigit))
                        Console.WriteLine("Invalid input. Surname cannot contain numbers or be empty.");
                } while (string.IsNullOrWhiteSpace(surname) || surname.Any(char.IsDigit));

                // --- Birth Date ---
                int year, month, day;
                while (true)
                {
                    Console.Write("Birth Year: ");
                    if (!int.TryParse(Console.ReadLine(), out year)) { Console.WriteLine("Invalid year."); continue; }

                    Console.Write("Birth Month: ");
                    if (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12) { Console.WriteLine("Invalid month."); continue; }

                    Console.Write("Birth Day: ");
                    if (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31) { Console.WriteLine("Invalid day."); continue; }

                    if (DateTime.TryParse($"{year}-{month}-{day}", out _))
                        break;
                    Console.WriteLine("Invalid date. Please try again.");
                }

                // --- Grade ---
                double grade;
                while (true)
                {
                    Console.Write("Grade: ");
                    if (double.TryParse(Console.ReadLine(), out grade))
                        break;
                    Console.WriteLine("Invalid input. Grade must be a number.");
                }

                // --- Add student, check for duplicate RollNumber ---
                bool added = false;
                do
                {
                    var student = new Student(roll, name, surname, new DateTime(year, month, day), grade);
                    added = _manager.AddStudent(student); // Returns false if duplicate

                    if (!added)
                    {
                        Console.WriteLine("Please enter a different Roll Number.");

                        // Ask for RollNumber again
                        while (true)
                        {
                            Console.Write("Roll Number: ");
                            if (int.TryParse(Console.ReadLine(), out roll))
                                break;
                            Console.WriteLine("Invalid input. Roll Number must be a number.");
                        }
                    }
                } while (!added);
            }
            catch
            {
                Console.WriteLine("An error occurred. Student was not added.");
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
