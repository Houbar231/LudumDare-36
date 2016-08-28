using UnityEngine;
using System.Collections;

public class MapTile {
    public GameObject TileGO;
    public TileData Data;

    public MapTile(int x, int y) {
        Data = new TileData(x, y);
        TileGO = new GameObject("Tile " + x + ", " + y);
        TileGO.transform.position = new Vector3(x, y,0.1f);
        TileGO.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.DefaultTileSprite;
    }
}
public class TileData {
    public int x, y;
    public bool IsWalkable = true; 
    public TileData(int x, int y) {
        this.x = x;
        this.y = y;
    }

}
