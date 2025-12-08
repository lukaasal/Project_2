using Project_2;
using Project_2.Models;

var manager = new StudentManager();
var listener = new KeyListener(manager);

listener.Run();