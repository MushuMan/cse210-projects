using Raylib_cs;
using System.Collections.Generic;

class InputHandler
{
    private (int dx, int dy) ProcessInput()
    {
        int dx = 0;
        int dy = 0;

        if (Raylib.IsKeyPressed(KeyboardKey.W) || Raylib.IsKeyPressed(KeyboardKey.Up) || Raylib.IsKeyPressedRepeat(KeyboardKey.W) || Raylib.IsKeyPressedRepeat(KeyboardKey.Up))
        {
            dy = -1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.S) || Raylib.IsKeyPressed(KeyboardKey.Down) || Raylib.IsKeyPressedRepeat(KeyboardKey.S) || Raylib.IsKeyPressedRepeat(KeyboardKey.Down))
        {
            dy = 1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.A) || Raylib.IsKeyPressed(KeyboardKey.Left) || Raylib.IsKeyPressedRepeat(KeyboardKey.A) || Raylib.IsKeyPressedRepeat(KeyboardKey.Left))
        {
            dx = -1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.D) || Raylib.IsKeyPressed(KeyboardKey.Right) || Raylib.IsKeyPressedRepeat(KeyboardKey.D) || Raylib.IsKeyPressedRepeat(KeyboardKey.Right))
        {
            dx = 1;
        }

        return (dx, dy);
    }

    public void HandleMovement(CharacterTile character, Dictionary<(int, int), Tile> wallTiles)
    {
        (int dx, int dy) = ProcessInput();
        character.Move(dx, dy, wallTiles);
    }
}