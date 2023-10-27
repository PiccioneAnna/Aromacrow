using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSpawnManager : MonoBehaviour
{
    private TilemapGenerationManager tilemapGenerationManager;

    public int[,] _cellularAutomata0;
    public int[,] _cellularAutomata1;
    public int[,] _cellularAutomata2;
    public int[,] _cellularAutomata3;

    public Tilemap _targetTilemap0;
    public Tilemap _targetTilemap1;
    public Tilemap _targetTilemap2;
    public Tilemap _targetTilemap3;
    public TileBase _activeTile;

    private int _width;
    private int _height;

    // Start is called before the first frame update
    void Start()
    {
        tilemapGenerationManager = GetComponent<TilemapGenerationManager>();

        _width = tilemapGenerationManager._width;
        _height = tilemapGenerationManager._height;

        PopulateData();

        // Initiating ground floor map
        Debug.Log("Initiating map population...");
        PopulateTilemap(_targetTilemap0, _cellularAutomata0);
        PopulateTilemap(_targetTilemap1, _cellularAutomata1);
        PopulateTilemap(_targetTilemap2, _cellularAutomata2);
        PopulateTilemap(_targetTilemap3, _cellularAutomata3);
    }

    void PopulateData()
    {
        _cellularAutomata0 = tilemapGenerationManager.GenerateMap(null);
        _cellularAutomata1 = tilemapGenerationManager.GenerateMap(_cellularAutomata0);
        _cellularAutomata2 = tilemapGenerationManager.GenerateMap(_cellularAutomata1);
        _cellularAutomata3 = tilemapGenerationManager.GenerateMap(_cellularAutomata2);
    }

    void PopulateTilemap(Tilemap tilemap, int[,] data)
    {
        // returns if the tilemap or the data is null
        if(tilemap == null || data == null)
        {
            return;
        }

        tilemap.ClearAllTiles();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (data[x,y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), _activeTile);
                }
            }
        }
    }
}
