using System;

public class World
{
    public static int Width { get; } = 10;
    public static int Height { get; } = 20;

    // NOTE: _tiles should be a pointer to terrains; not an actual object!
    private Terrain[,] _tiles = new Terrain[Width, Height];

    private Terrain _grassTerrain;
    private Terrain _hillTerrain;
    private Terrain _riverTerrain;

    public World()
    {
        _grassTerrain = new Terrain(1, false, 2f, "grass");
        _hillTerrain = new Terrain(3, false, 5f, "hill");
        _riverTerrain = new Terrain(2, true, 1f, "river");
    }

    public void GenerateTerrain()
    {
        Random r = new Random();
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                // sprinkle some hills
                if (r.Next(10) > 7)
                    _tiles[x, y] = _hillTerrain;
                else
                    _tiles[x, y] = _grassTerrain;
            }
        }

        // lay a river
        int x1 = r.Next(Width);
        for (int y = 0; y < Height; y++)
        {
            _tiles[x1, y] = _riverTerrain;
        }
    }

    public Terrain GetTile(int x, int y)
    {
        return _tiles[x, y];
    }
}
