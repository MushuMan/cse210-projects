using System.Security.Cryptography.X509Certificates;

abstract class Tile
{
    protected int _x;
    protected int _y;
    protected bool _walkable;

    public Tile(int x, int y, bool walkable)
    {
        _x = x;
        _y = y;
        _walkable = walkable;
    }

    public int GetX()
    {
        return _x;
    }

    public int GetY()
    {
        return _y;
    }

    public bool IsWalkable()
    {
        return _walkable;
    }
}