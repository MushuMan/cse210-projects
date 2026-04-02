using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Maze maze = new Maze(31, 31);

        CharacterTile character = new CharacterTile(0, 0, false, 31, 31);

        InputHandler input = new InputHandler();

        WindowManager mainWindow = new WindowManager(785, 785);
        mainWindow.setMaze(maze);
        mainWindow.getCharacter(character);
        mainWindow.getInput(input);
        mainWindow.startWindow();
    }
}