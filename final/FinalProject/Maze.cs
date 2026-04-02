using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Maze
{
    private int _width;
    private int _height;
    private Dictionary<(int, int), Tile> _walls;
    private Dictionary<(int, int), Tile> _floors;
    private List<(int dx, int dy)> _generationDirections;
    private (int x, int y) _start;
    private (int x, int y) _finish;
    private int _maxDepth;

    public Maze(int width, int height)
    {
        _width = width;
        _height = height;
        _walls = new Dictionary<(int, int), Tile>();
        _floors = new Dictionary<(int, int), Tile>();
        _generationDirections = new List<(int dx, int dy)>
        {
          (0, -2),  // up
          (0, 2),   // down
          (-2, 0),  // left
          (2, 0)    // right
        };
        _start = (0, 0);
        _finish = (0, 0);
        _maxDepth = 0;

        generateMaze();
    }

    private void generateMaze()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                WallTile newWall = new WallTile(x, y, false);
                _walls.Add((x, y), newWall);

                FloorTile newFloor = new FloorTile(x, y, true);
                _floors.Add((x, y), newFloor);
            }    
        }

        _walls.Remove(_start);

        generateMazeDFS(_start.x, _start.y, _maxDepth);
    }

    private void generateMazeDFS(int x, int y, int depth)
    {
        List<(int dx, int dy)> directions = new List<(int, int)>(_generationDirections);
        shuffleDirections(directions);

        foreach (var (dx, dy) in directions)
        {
            int nx = x + dx;
            int ny = y + dy;

            if (nx >= 0 && nx <= _width && ny >= 0 && ny <= _height)
            {
                if (_walls.ContainsKey((nx, ny)))
                {
                    int wallX = x + dx / 2;
                    int wallY = y + dy / 2;
                    
                    _walls.Remove((wallX, wallY));
                    _walls.Remove((nx, ny));

                    if (depth + 1 > _maxDepth)
                    {
                        _maxDepth = depth + 1;
                        _finish = (nx, ny);
                    }
                    generateMazeDFS(nx, ny, depth + 1);
                }
            }
        }
    }

    private void shuffleDirections(List<(int, int)> list)
    {
        Random rand = new Random();
        for (int i = 0; i < list.Count; i++)
        {
            int j = rand.Next(i, list.Count);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    public Dictionary<(int, int), Tile> getWalls()
    {
        return _walls;
    }

    public Dictionary<(int, int), Tile> getFloors()
    {
        return _floors;
    }

    public (int x, int y) getFinish()
    {
        return _finish;
    }
}