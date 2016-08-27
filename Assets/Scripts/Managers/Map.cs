using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public static Map Instance;
    public MapTile[,] Tiles;
    void Awake() {
        Instance = this;
    }
    void Start() {
        Tiles = new MapTile[GeneralReference.r.Width, GeneralReference.r.Height];
        for(int i = 0; i < GeneralReference.r.Width; i++) {
            for(int j = 0; j < GeneralReference.r.Height; j++) {
                Tiles[i, j] = new MapTile(i, j);
            }
        }
    }
}
