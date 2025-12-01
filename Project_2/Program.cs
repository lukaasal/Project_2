using System;
using Project_2.Models;

namespace Project_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            KeyListener listener = new KeyListener(manager);
            listener.Run();
        }
    }
}
