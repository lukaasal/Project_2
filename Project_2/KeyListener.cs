using System;
using Project_2.Models;

namespace Project_2
{
    public class KeyListener
    {
        private StudentManager manager;

        public KeyListener(StudentManager manager)
        {
            this.manager = manager;
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

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudentFromUser();
                        break;
                    case "2":
                        RemoveStudentFromUser();
                        break;
                    case "3":
                        manager.ShowAll();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        private void AddStudentFromUser()
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter Birth Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter Birth Month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter Birth Day: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade: ");
            double grade = double.Parse(Console.ReadLine());

            Student s = new Student(roll, name, surname, new DateTime(year, month, day), grade);
            manager.AddStudent(s);
        }

        private void RemoveStudentFromUser()
        {
            Console.Write("Enter Roll Number to Remove: ");
            int roll = int.Parse(Console.ReadLine());

            manager.RemoveStudent(roll);
        }
    }
}
