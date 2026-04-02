using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Raylib_cs;

class WindowManager
{
    private int _windowWidth;
    private int _windowHeight;
    private int _tileSize;
    private Maze _maze;
    private CharacterTile _character;
    private InputHandler _input;

    public WindowManager(int width, int height)
    {
        _windowWidth = width;
        _windowHeight = height;
        _tileSize = 25;
    }

    public void renderMaze()
    {
        Dictionary<(int, int), Tile> walls = _maze.getWalls();
        Dictionary<(int, int), Tile> floors = _maze.getFloors();

        foreach (var ((x, y), tile) in floors)
        {
            int rectX = x * _tileSize + 5;
            int rectY = y * _tileSize + 5;

            if ((x, y) == _maze.getFinish())
            {
                Raylib.DrawRectangle(rectX, rectY, _tileSize, _tileSize, Color.Red);
            }
            else
            {
                Raylib.DrawRectangle(rectX, rectY, _tileSize, _tileSize, Color.RayWhite);
            }
        }

        foreach (var ((x, y), tile) in walls)
        {
            int rectX = x * _tileSize + 5;
            int rectY = y * _tileSize + 5;

            Raylib.DrawRectangle(rectX, rectY, _tileSize, _tileSize, Color.Black);
        }
    }

    public void renderCharacter()
    {
        int x = _character.getX();
        int y = _character.getY();

        x = x * _tileSize + 5;
        y = y * _tileSize + 5;

        Raylib.DrawRectangle(x, y, _tileSize, _tileSize, Color.Green);
    }

    public void startWindow()
    {
        Raylib.InitWindow(_windowWidth, _windowHeight, "MazeGame");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            _input.handleMovement(_character, _maze.getWalls());
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            renderMaze();
            renderCharacter();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    public void setMaze(Maze maze)
    {
        _maze = maze;
    }

    public void getCharacter(CharacterTile character)
    {
        _character = character;
    }

    public void getInput(InputHandler input)
    {
        _input = input;
    }
}