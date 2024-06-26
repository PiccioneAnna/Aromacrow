using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapReader : MonoBehaviour
{
    #region fields
    [SerializeField] Tilemap tilemap;
    private Vector3 worldPosition;
    #endregion

    public Vector3Int GetGridPosition(Tilemap tm, Vector2 pos, bool mousePos)
    {
        tilemap = tm;

        if (tilemap == null) { return Vector3Int.zero; }

        if (mousePos)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(pos);
        }
        else
        {
            worldPosition = pos;
        }

        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);
        gridPosition = new Vector3Int(gridPosition.x, gridPosition.y, 0);
        return gridPosition;
    }

    public TileBase GetTileBase(Tilemap tm, Vector3Int gridPos)
    {
        tilemap = tm;

        if (tilemap == null) { return null; }

        gridPos = tilemap.WorldToCell(new Vector3(worldPosition.x, worldPosition.y, 0));
        TileBase tile = tilemap.GetTile(gridPos);

        return tile;
    }
}
