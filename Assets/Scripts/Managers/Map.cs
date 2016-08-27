using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public static Map Instance;
    public int Width, Height;
    public MapTile[,] Tiles;
    void Awake() {
        Instance = this;
    }
    void OnEnable() {
        Tiles = new MapTile[Width, Height];
        for(int i = 0; i < Width; i++) {
            for(int j = 0; j < Height; j++) {
                Tiles[i, j] = new MapTile(i, j);
            }
        }
    }
}
