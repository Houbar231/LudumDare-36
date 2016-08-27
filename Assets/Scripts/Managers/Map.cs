using UnityEngine;
using System.Collections.Generic;

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
        Enemy.Instance.ValidSpawnTiles = GetEdgeTiles();
        for(int i = 0; i < 4; i++) {
            Enemy.Instance.SpawnEnemyUnit();
        }
    }
    public List<MapTile> GetEdgeTiles() {
        List<MapTile> ret = new List<MapTile>();
        for(int i = 0; i < GeneralReference.r.Width; i++) {
            for(int j = 0; j < GeneralReference.r.Height; j++) {
                if(i == 0 || i == GeneralReference.r.Width - 1 || j == 0 || j == GeneralReference.r.Height-1) {
                    ret.Add(Tiles[i, j]);
                }
            }
        }
        return ret;
    }
}
