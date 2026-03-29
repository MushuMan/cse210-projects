using System.Runtime.CompilerServices;
using Raylib_cs;

class WindowManager
{
    private int _windowWidth;
    private int _windowHeight;
    private int _tileSize;
    private Maze _maze;

    public WindowManager(int width, int height)
    {
        _windowWidth = width;
        _windowHeight = height;
        _tileSize = 25;
    }

    public void renderMaze()
    {
        List<Tile> grid = _maze.getGrid();
        foreach (Tile tile in grid)
        {
            int x = tile.getX();
            int y = tile.getY();

            x = x * (_tileSize + 2) + 5;
            y = y * (_tileSize + 2) + 5;

            Raylib.DrawRectangle(x, y, _tileSize, _tileSize, Color.Black);
        }
    }

    public void startWindow()
    {
        Raylib.InitWindow(_windowWidth, _windowHeight, "MazeGame");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            renderMaze();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    public void setMaze(Maze maze)
    {
        _maze = maze;
    }
}