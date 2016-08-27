using UnityEngine;
using System.Collections;

public class MapTile {
    public GameObject TileGO;
    public TileData Data;

    public MapTile(int x, int y) {
        Data = new TileData(x, y);
        TileGO = new GameObject("Tile " + x + ", " + y);
        TileGO.transform.position = new Vector3(x, y);// + new Vector3(-(GeneralReference.r.Width / 2f), 0, -(GeneralReference.r.Height / 2f))
        TileGO.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.DefaultTileSprite;
    }
}
public class TileData {
    public int x, y;
    public TileData(int x, int y) {
        this.x = x;
        this.y = y;
    }

}
