using System.Collections.Generic;

class CharacterTile : Tile
{
    private int _moves;
    private int _mazeWidth;
    private int _mazeHeight;
    
    public CharacterTile(int x, int y, bool walkable, int mazeWidth, int mazeHeight) : base(x, y, walkable)
    {
        _moves = 0;
        _mazeWidth = mazeWidth;
        _mazeHeight = mazeHeight;
    }

    public void Move(int dx, int dy, Dictionary<(int, int), Tile> wallTiles)
    {
        int lastX = _x;
        int lastY = _y;

        if (wallTiles.ContainsKey((_x + dx, _y + dy)))
        {
            return;
        }

        _x = _x + dx;
        if (_x < 0)
        {
            _x = 0;
        }
        else if (_x > _mazeWidth - 1)
        {
            _x = _mazeWidth - 1;
        }

        _y = _y + dy;
        if (_y < 0)
        {
            _y = 0;
        }
        else if (_y > _mazeHeight - 1)
        {
            _y = _mazeHeight - 1;
        }

        if (_x != lastX || _y != lastY)
        {
            _moves += 1;
        }
    }

    public int GetMoves()
    {
        return _moves;
    }
}