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
    private bool _gameFinished;

    public WindowManager(int mazeWidth, int mazeHeight)
    {
        _tileSize = 25;
        _windowWidth = mazeWidth * _tileSize + 10;
        _windowHeight = mazeHeight * _tileSize + 10;
    }

    public void RenderMaze()
    {
        Dictionary<(int, int), Tile> walls = _maze.GetWalls();
        Dictionary<(int, int), Tile> floors = _maze.GetFloors();

        foreach (var ((x, y), tile) in floors)
        {
            int rectX = x * _tileSize + 5;
            int rectY = y * _tileSize + 5;

            if ((x, y) == _maze.GetFinish())
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

    public void RenderCharacter()
    {
        int x = _character.GetX();
        int y = _character.GetY();

        x = x * _tileSize + 5;
        y = y * _tileSize + 5;

        Raylib.DrawRectangle(x, y, _tileSize, _tileSize, Color.Green);
    }

    public void StartWindow()
    {
        _gameFinished = false;
        Raylib.InitWindow(_windowWidth, _windowHeight, "MazeGame");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose() && !_gameFinished)
        {
            _input.HandleMovement(_character, _maze.GetWalls());
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            RenderMaze();
            RenderCharacter();

            Raylib.EndDrawing();

            if (_maze.GetFinish() == (_character.GetX(), _character.GetY()))
            {
                _gameFinished = true;
            }
        }

        Raylib.CloseWindow();
    }

    public void SetMaze(Maze maze)
    {
        _maze = maze;
    }

    public void SetCharacter(CharacterTile character)
    {
        _character = character;
    }

    public void SetInput(InputHandler input)
    {
        _input = input;
    }
}