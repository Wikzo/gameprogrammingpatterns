public class Terrain
{
    private int _moveCost;
    private bool _isWater;
    private float _texture;
    private string _terrainType;

    public Terrain(int moveCost, bool isWater, float texture, string terrainType)
    {
        this._moveCost = moveCost;
        this._isWater = isWater;
        this._texture = texture;
        this._terrainType = terrainType;
    }

    public int GetMoveCost()
    {
        return _moveCost;
    }

    public bool IsWater()
    {
        return _isWater;
    }

    public float GetTexture()
    {
        return _texture;
    }
    public string GetTerrainType()
    {
        return _terrainType;
    }
}
