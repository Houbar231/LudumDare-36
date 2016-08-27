using UnityEngine;
using System.Collections;

public class MapTile {
    public int x, y;
    public bool IsWalkable;

    public MapTile(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
