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

    public int getX()
    {
        return _x;
    }

    public int getY()
    {
        return _y;
    }

    public bool isWalkable()
    {
        return _walkable;
    }

    public abstract void renderTile();
}