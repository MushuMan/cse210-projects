using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Maze maze = new Maze();

        WindowManager mainWindow = new WindowManager(800, 600);
        mainWindow.setMaze(maze);
        mainWindow.startWindow();
    }
}