class Maze
{
    private int _width;
    private int _height;
    private List<Tile> _grid;

    public Maze()
    {
        Console.Write("Please enter maze width: ");
        int width = int.Parse(Console.ReadLine());

        Console.Write("Please enter maze height: ");
        int height = int.Parse(Console.ReadLine());

        _width = width;
        _height = height;
        _grid = new List<Tile>();

        generateMaze();
    }

    private void generateMaze()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                FloorTile newTile = new FloorTile(x, y, true);
                _grid.Add(newTile);
            }    
        }
    }

    public List<Tile> getGrid()
    {
        return _grid;
    }

    public void setTile(int x, int y, Tile tile)
    {
        
    }
}